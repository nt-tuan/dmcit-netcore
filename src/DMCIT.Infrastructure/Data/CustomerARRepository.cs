using DMCIT.Core.Entities;
using DMCIT.Core.Entities.Accounting;
using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Entities.Messaging.TemplateMessage;
using DMCIT.Core.Entities.Reports;
using DMCIT.Core.Entities.Reports.Templates;
using DMCIT.Core.Entities.Sales;
using DMCIT.Core.Entities.Templates.TextParser;
using DMCIT.Core.Interfaces;
using DMCIT.Core.Services;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Services;
using EFCore.BulkExtensions;
using Hangfire.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class CustomerARRepository : ICustomerARRepository
    {
        private const string AR_ACCOUNT_PREFIX = "131";

        private readonly AppDbContext _db;
        private readonly IRepository _rep;
        private readonly IMessageReceiverRepository _iReceiver;
        private readonly ISaleRepository _sale;
        private readonly IMessagingRepository _messaging;
        private readonly ISettingRepository _setting;
        private readonly ISendCustomerARService _service;
        private readonly ISendMessageService _sendMessageService;
        private readonly IDiary131Service _diary131Service;
        private readonly IProcessManagerService _processService;
        private readonly ICoreRepository _core;
        private readonly ITemplateRepository _template;
        public CustomerARRepository(AppDbContext db, IRepository rep, ISaleRepository sale, IMessagingRepository messaging, IMessageReceiverRepository receiver, ISettingRepository setting, ISendCustomerARService service, ICoreRepository core,
            IProcessManagerService processService, IDiary131Service diary131Service, ITemplateRepository template,
            ISendMessageService sendMessageService)
        {
            _db = db;
            _rep = rep;
            _sale = sale;
            _messaging = messaging;
            _iReceiver = receiver;
            _setting = setting;
            _service = service;
            _processService = processService;
            _diary131Service = diary131Service;
            _core = core;
            _template = template;
            _sendMessageService = sendMessageService;
        }

        #region HELP METHODS
        async Task<IEnumerable<CustomerAccounting>> getAPCustomerARs(AccountingPeriod ap, Func<IQueryable<CustomerAR>, IQueryable<CustomerAR>> extend = null)
        {
            var apCusAR = new List<CustomerAccounting>();
            if (ap != null)
            {
                var query = _db.CustomerARs.AsNoTracking().Where(u => u.DispatchAccountingPeriod.Id == ap.GetId());
                if (extend != null)
                {
                    query = extend(query);
                }
                apCusAR = await query
                    .Select(u => new CustomerAccounting
                    {
                        CustomerCode = u.CustomerCode,
                        DistributorCode = u.DistributorCode,
                        Amount = u.Amount
                    }
                ).ToListAsync();
            }

            return apCusAR;
        }

        async Task<CustomerAccounting> getLastAPCustomerAR(string customerCode, string distributorCode, DateTime to)
        {
            var ap = await _core.FindLastClosedAccountingPeriod(to);
            CustomerAccounting apCusAR = null;
            if (ap != null)
            {
                apCusAR = await _db.CustomerARs.AsNoTracking().Where(u => u.DispatchAccountingPeriod.Id == ap.GetId() && u.CustomerCode == customerCode && u.DistributorCode == distributorCode)
                    .Select(u => new CustomerAccounting
                    {
                        CustomerCode = u.Customer.Code,
                        DistributorCode = u.DistributorCode,
                        Amount = u.Amount
                    }
                ).FirstOrDefaultAsync();
                return apCusAR;
            }
            return null;
        }

        /// <summary>
        /// Get money ammount in each customer accounts on Diary131 table
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="extend"></param>
        /// <returns></returns>
        async Task<IEnumerable<CustomerAccounting>> calculateCustomerAccountsAmount(DateTime? from, DateTime? to, Func<IQueryable<Diary131>, IQueryable<Diary131>> extend, Func<IQueryable<Diary131>, IQueryable<CustomerAccounting>> groupMethod)
        {
            var q = _db.Set<Diary131>().AsQueryable();
            q = q.Where(u => u.DateRemoved == null && u.Locked);
            if (extend != null)
                q = extend(q);
            if (from != null)
                q = q.Where(u => u.ReceiptDate >= from);
            if (to != null)
                q = q.Where(u => u.ReceiptDate < to);
            var groupq = groupMethod(q);

            var rs = await groupq.ToListAsync();
            return rs;
        }
        async Task<IEnumerable<CustomerAccounting>> calculateCustomerARs(DateTime? from, DateTime to, Func<IQueryable<Diary131>, IQueryable<Diary131>> extend)
        {
            //TODO: change to linq
            Func<IQueryable<Diary131>, IQueryable<Diary131>> creditQ = q =>
            {
                var frs = q;
                if (extend != null)
                {
                    frs = extend(frs);
                }
                return frs.Where(u => u.CreditAccount.StartsWith(AR_ACCOUNT_PREFIX));
            };

            Func<IQueryable<Diary131>, IQueryable<CustomerAccounting>> creditG = q => q.GroupBy(u => new { u.DetailCredit1, u.DistributorCode, u.CustomerCode })
               .Select(v => new CustomerAccounting
               {
                   CustomerCode = v.Key.CustomerCode,
                   DistributorCode = v.Key.DistributorCode,
                   Amount = v.Sum(u => u.MoneyAmount)
               });

            Func<IQueryable<Diary131>, IQueryable<Diary131>> debitQ = q =>
            {
                var frs = q;
                if (extend != null)
                {
                    frs = extend(frs);
                }
                return frs.Where(u => u.DebitAccount.StartsWith(AR_ACCOUNT_PREFIX));
            };

            Func<IQueryable<Diary131>, IQueryable<CustomerAccounting>> debitG = q => q.GroupBy(u => new { u.DetailDebit1, u.DistributorCode, u.CustomerCode })
               .Select(v => new CustomerAccounting
               {
                   CustomerCode = v.Key.CustomerCode,
                   DistributorCode = v.Key.DistributorCode,
                   Amount = v.Sum(u => u.MoneyAmount)
               });

            var credit = await calculateCustomerAccountsAmount(from, to, creditQ, creditG);
            var debit = await calculateCustomerAccountsAmount(from, to, debitQ, debitG);

            var set = new HashSet<CustomerAccounting>();
            foreach (var item in credit)
            {
                item.Amount = -item.Amount;
                set.Add(item);
            }
            foreach (var item in debit)
            {
                set.Add(item);
            }

            var rs = set.ToList()
                .GroupBy(u => new { u.CustomerCode, u.DistributorCode })
                .Select(u => new CustomerAccounting
                {
                    CustomerCode = u.Key.CustomerCode,
                    DistributorCode = u.Key.DistributorCode,
                    Amount = u.Sum(v => v.Amount)
                });
            return rs;
        }
        async Task<CustomerAccounting> calculateCustomerAR(string customerCode, string distributorCode, DateTime? from, DateTime to)
        {
            Func<IQueryable<Diary131>, IQueryable<Diary131>> query = u => u.Where(v => v.CustomerCode == customerCode && v.DistributorCode == distributorCode);

            var lastAR = await calculateCustomerARs(from, to, query);

            return lastAR.FirstOrDefault();
        }

        async Task<IEnumerable<CalculatedCustomerPayment>> calculateCustomerPayment(int distributorId, DateTime? from, DateTime? to)
        {
            var distributor = await _sale.GetDistributorById(distributorId);
            var q = _db.Set<Diary131>().AsQueryable();
            q = q.Where(u => u.DateRemoved == null && u.Locked && u.DistributorCode == distributor.Code && u.CreditAccount.StartsWith("131"));

            if (from != null)
                q = q.Where(u => u.ReceiptDate >= from);

            if (to != null)
                q = q.Where(u => u.ReceiptDate < to);

            var groupq = q
                .GroupBy(u => new { u.CustomerCode, u.DistributorCode, u.ReceiptDate.Date })
                .Select(u => new CalculatedCustomerPayment
                {
                    Amount = u.Sum(v => v.MoneyAmount),
                    CustomerCode = u.Key.CustomerCode,
                    DistributorCode = u.Key.DistributorCode,
                    ReceiptDate = u.Key.Date
                }).Where(u => u.Amount > 100000);
            return await groupq.ToListAsync();
        }
        #endregion


        public async Task<CalculatedCustomerLiabilityQuery> calculateCustomerAR(string customerCode, string distributorCode, DateTime to)
        {
            var ap = await _core.FindLastClosedAccountingPeriod(to);

            var apAR = await getLastAPCustomerAR(customerCode, distributorCode, to);

            DateTime? from = null;
            if (ap != null)
                from = ap.AccountingEndTime;

            var calAR = await calculateCustomerAR(customerCode, distributorCode, from, to);

            if (apAR == null && calAR == null)
                return null;

            decimal amount = 0;
            if (apAR != null)
                amount += apAR.Amount;
            if (calAR != null)
                amount += calAR.Amount;
            var rs = new CalculatedCustomerLiabilityQuery
            {
                Amount = amount,
                CustomerCode = customerCode,
                DistributorCode = distributorCode
            };
            return rs;
        }

        public async Task fillExtraCustomerInfo(IEnumerable<CalculatedCustomerLiabilityQuery> data)
        {
            var par = new GetListParams<Customer>();
            par.SetGetAllItems();
            var customers = await _sale.GetCustomers(par);
            var dict = new Dictionary<int?, Dictionary<string, Customer>>();
            foreach (var item in customers)
            {
                if (item.DistributorId == null)
                    continue;
                int d = item.DistributorId.Value;
                Dictionary<string, Customer> subDict;
                if (!dict.ContainsKey(d))
                {
                    subDict = new Dictionary<string, Customer>();
                    dict.Add(d, subDict);
                }
                else
                {
                    subDict = dict[d];
                }
                if (!subDict.ContainsKey(item.Code))
                    subDict.Add(item.Code, item);
            }

            //TODO: remove this
            foreach (var item in data)
            {
                if (item.DistributorId != null)
                {
                    if (!dict.ContainsKey(item.DistributorId) || !dict[item.DistributorId].ContainsKey(item.CustomerCode))
                        continue;
                    var customer = dict[item.DistributorId][item.CustomerCode];
                    item.Customer = customer;
                    item.CustomerId = customer.GetId();
                }
            }

        }

        public async Task<IEnumerable<CalculatedCustomerLiabilityQuery>> calculateCustomerARs(Distributor distributor, DateTime to)
        {
            var ap = await _core.FindLastClosedAccountingPeriod(to);
            DateTime? from = null;
            if (ap != null)
                from = ap.AccountingEndTime;

            var calAR = await calculateCustomerARs(from, to, u => u.Where(v => v.DistributorCode == distributor.Code));
            var apAR = await getAPCustomerARs(ap, u => u.Where(v => v.DistributorCode == distributor.Code));
            var merge = calAR.Concat(apAR)
                .GroupBy(u => new
                {
                    u.CustomerCode,
                    u.DistributorCode
                }).Select(
                u => new CalculatedCustomerLiabilityQuery
                {
                    Amount = u.Sum(v => v.Amount),
                    DistributorCode = u.Key.DistributorCode,
                    CustomerCode = u.Key.CustomerCode,
                    Distributor = distributor,
                    DistributorId = distributor.GetId(),
                    At = to
                });
            return merge;
        }


        async Task<IEnumerable<CalculatedCustomerLiabilityQuery>> calculateCustomerARs(IEnumerable<Distributor> distributors, DateTime to)
        {
            var data = new List<CalculatedCustomerLiabilityQuery>();
            foreach (var distributor in distributors)
            {
                var ar = await calculateCustomerARs(distributor, to);
                data.AddRange(ar);
            }

            await fillExtraCustomerInfo(data);
            return data;
        }

        #region CUSTOMER AR
        public async Task<IEnumerable<CalculatedCustomerLiabilityQuery>> CalculateCustomerARs(DateTime to)
        {
            var distributors = await _sale.GetDistributors();
            var data = await calculateCustomerARs(distributors, to);
            return data;
        }


        public async Task<IEnumerable<CalculatedCustomerLiabilityQuery>> CalculateCustomerARs(IEnumerable<int> distributors, DateTime to)
        {
            var entities = new List<Distributor>();
            foreach (var id in distributors)
            {
                var d = await _sale.GetDistributorById(id);
                if (d != null)
                {
                    entities.Add(d);
                }
            }

            var data = await calculateCustomerARs(entities, to);
            return data;
        }


        public async Task<IEnumerable<CustomerARNow>> GetStoredCustomerAR(GetListParams<CustomerARNow> p)
        {
            var list = await _rep.ListRaw(p);
            foreach (var item in list)
            {
                if (item.CustomerId != null)
                    item.Customer = await _sale.GetCustomerById(item.CustomerId.Value);
            }
            return list;
        }


        public async Task<int> GetStoredCustomerARCount(GetListParams<CustomerARNow> p)
        {
            var count = await _rep.CountRaw(p);
            return count;
        }

        public async Task UpdateCustomerARs(AccountingPeriod ap, AppUser actor, PerformContext context)
        {
            DateTime to = ap.AccountingEndTime;
            await _diary131Service.CalculateAR(to, actor, context);
            var ls = await CalculateCustomerARs(to);
            var entities = new List<CustomerAR>();
            foreach (var item in ls)
            {
                if (item.CustomerCode == null)
                    item.CustomerCode = "-";
                var e = new CustomerAR
                (item, ap.GetId());
                var any = await _sale.GetSimplyCustomerByCode(item.CustomerCode);
                if (any != null)
                {
                    e.CustomerId = any.GetId();
                }
                entities.Add(e);
            }

            await _db.BulkDeleteAsync(await _db.CustomerARs.AsNoTracking().Where(u => u.DispatchAccountingPeriodId == ap.GetId()).ToListAsync());
            await _db.BulkInsertAsync(entities);
            await _diary131Service.EndCalculateAR(entities, to, context);
        }

        public async Task<SentMessage> GetCustomerARMessageContent(CustomerARMessage cp)
        {
            var s = _setting.GetSettingStore();
            var general = s.GetSetting<GeneralSetting>();
            //var mSetting = s.GetSetting<MessageSetting>();
            CultureInfo ci = CultureInfo.GetCultureInfo(general.CultureInfo);
            var mContent = new CustomerARMessageContentModel();
            mContent.Customer = cp.Customer.GetDisplayName();
            mContent.Amount = cp.Amount.ToString(ci);
            mContent.ReceiptDate = cp.At.ToString(ci);
            var parser = await _template.GetParserAsync<TextParser, CustomerARMessageTemplate>();
            var sms = await parser.Parse(mContent.GetValue());

            return new SentMessage(sms, cp.ReceiverProvider.GetId());
        }

        public async Task<IEnumerable<CustomerARMessage>> GetCustomerARMessages(IEnumerable<int> distributors, IEnumerable<int> providerIds, DateTime at)
        {
            DateTime now = DateTime.Now;
            var data = await CalculateCustomerARs(distributors, at);

            //TODO: remove this, i set this small to test
            //data = data.Take(100);
            var generalSetting = _setting.GetSettingStore().GetSetting<GeneralSetting>();
            var providers = new List<MessageServiceProvider>();
            foreach (var id in providerIds)
            {
                var e = await _iReceiver.GetProviderById(id, false);
                if (e != null)
                    providers.Add(e);
            }

            var mdata = new List<CustomerARMessage>();

            //100 rows only
            foreach (var item in data)
            {
                if (item.Customer == null)
                {
                    mdata.Add(new CustomerARMessage(item));
                    continue;
                }

                var receiver = await _iReceiver.GetCustomerReceiver(item.Customer.GetId());
                if (receiver == null)
                {
                    mdata.Add(new CustomerARMessage(item));
                    continue;
                }

                var receiverProviders = await _iReceiver.GetReceiverProviders(receiver.GetId(), providers.Select(u => u.GetId()));
                if (receiverProviders == null || receiverProviders.Count == 0)
                {
                    mdata.Add(new CustomerARMessage(item));
                    continue;
                }

                //get provider info
                //var customer = await _sale.GetCustomerById(item.customerId);
                foreach (var rpItem in receiverProviders)
                {
                    var ar = new CustomerARMessage
                    (item);
                    ar.ReceiverProvider = rpItem;
                    mdata.Add(ar);
                }

            }
            return mdata;
        }

        public async Task SendCustomerAR(IEnumerable<int> distributors, IEnumerable<int> providers, DateTime endDate, AppUser actor, PerformContext context)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region CUSTOMER PAYMENT
        public async Task<IEnumerable<CustomerPayment>> GetCustomerPayment(int distributor, DateTime from, DateTime to)
        {
            var cp = await _db.CustomerPayments.Where(u => u.DistributorId == distributor && u.ReceiptDate >= from && u.ReceiptDate < to && u.SentMessageId == null).ToListAsync();
            foreach (var item in cp)
            {
                if (item.CustomerId != null)
                    item.Customer = await _sale.GetCustomerById(item.CustomerId.Value);
                if (item.DistributorId != null)
                    item.Distributor = await _sale.GetDistributorById(item.DistributorId.Value);
            }
            return cp;
        }

        async Task<CustomerPayment> getCalculatedCustomerPayment(string cusCode, string disCode, DateTime at, decimal payment, decimal ar)
        {
            return await _db.CustomerPayments.Where(u => u.CustomerCode == cusCode && u.DistributorCode == disCode && u.ReceiptDate == at && u.Amount == payment && u.ARAmount == ar).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<CustomerPayment>> CalculateCustomerPayments(int distributorId, DateTime from, DateTime to)
        {
            var distributor = await _sale.GetDistributorById(distributorId);
            var distributorCode = distributor.Code;
            var cusPayment = (await calculateCustomerPayment(distributorId, from, to)).Select(u => new CustomerPayment(u)).ToList();

            var now = DateTime.Now;
            var updatePayments = new List<CustomerPayment>();
            for (var i = 0; i < cusPayment.Count(); i++)
            {
                var item = cusPayment[i];
                item.DateCreated = now;

                //Calculate customer AR
                var endOfReceiptDate = item.ReceiptDate.Date.AddDays(1);
                var cusAccounting = await
                calculateCustomerAR(item.CustomerCode, distributorCode, endOfReceiptDate);
                item.ARAmount = cusAccounting?.Amount;

                //Get stored customerpayment, if value has been stored then skip updating
                var storedPayment = await getCalculatedCustomerPayment(item.CustomerCode, item.DistributorCode, item.ReceiptDate, item.Amount, item.ARAmount ?? 0);

                if (storedPayment != null)
                {
                    item.ARAmount = storedPayment.ARAmount;
                    item.DistributorId = storedPayment.DistributorId;
                    item.CustomerId = storedPayment.CustomerId;
                    item.SentMessageId = storedPayment.SentMessageId;
                    continue;
                }

                //Get reference customer and distributor
                item.DistributorId = distributor.GetId();
                var customer = await _sale.GetCustomerByCode(item.CustomerCode, distributorId);

                if (customer != null)
                {
                    item.CustomerId = customer.GetId();
                }

                //Add customerpayment to update list
                updatePayments.Add(item);
            }

            await _db.BulkInsertOrUpdateAsync(updatePayments);
            return cusPayment;
        }

        public async Task<CustomerPayment> GetLastCustomerPayment(string code)
        {
            return await _db.CustomerPayments.AsNoTracking().Where(u => u.DistributorCode == code).OrderByDescending(u => u.ReceiptDate).FirstOrDefaultAsync();
        }

        public async Task BulkUpdateCustomerPayment(IEnumerable<CustomerPayment> customerPayment)
        {
            await _db.BulkUpdateAsync(customerPayment.ToList());
        }

        public async Task<IEnumerable<CustomerPaymentMessage>> GetCustomerPaymentMessage(int distributor, IEnumerable<int> _providers, DateTime from, DateTime to)
        {
            var data = await GetCustomerPayment(distributor, from, to);

            var providers = new List<MessageServiceProvider>();
            foreach (var item in _providers)
            {
                providers.Add(await _iReceiver.GetProviderById(item, false));
            }

            var result = new List<CustomerPaymentMessage>();
            foreach (var item in data)
            {
                if (item.Customer == null)
                    continue;
                var receiver = await _iReceiver.GetCustomerReceiver(item.Customer.GetId());
                if (receiver == null)
                    continue;
                var receiverProviders = await _iReceiver.GetReceiverProviders(receiver.GetId(), providers.Select(u => u.GetId()));
                foreach (var rrItem in receiverProviders)
                {
                    var p = providers.Where(u => u.GetId() == rrItem.MessageServiceProviderId).FirstOrDefault();
                    if (p == null)
                        continue;
                    var e = new CustomerPaymentMessage();
                    e.CustomerPayment = item;
                    rrItem.MessageServiceProvider = p;
                    rrItem.MessageReceiver = receiver;
                    e.ReceiverProvider = rrItem;
                    result.Add(e);
                }
            }

            await genereateMessageContents(result);
            return result;
        }

        CustomerPaymentMessageContentModel generateMessageContent(CustomerPaymentMessage payment, GeneralSetting general, CultureInfo ci)
        {
            var content = new CustomerPaymentMessageContentModel();
            content.Customer = payment.CustomerPayment.Customer.GetDisplayName(); ;
            content.PaymentAmount = payment.CustomerPayment.Amount.ToString(general.NumbericMoneyFormat, ci);
            content.ReceiptDate = payment.CustomerPayment.ReceiptDate.ToString(general.ShortDateTimeFormat, ci);
            content.ARAmount = (payment.CustomerPayment.ARAmount ?? 0).ToString(general.NumbericMoneyFormat, ci);
            return content;
        }

        async Task genereateMessageContents(IEnumerable<CustomerPaymentMessage> payments)
        {
            var s = _setting.GetSettingStore();
            var general = s.GetSetting<GeneralSetting>();
            CultureInfo ci = CultureInfo.GetCultureInfo(general.CultureInfo);
            var parser = await _template.GetParserAsync<TextParser, CustomerPaymentMessageTemplate>();
            foreach (var item in payments)
            {
                var messageContent = generateMessageContent(item, general, ci);
                item.MessageContent = await parser.Parse(messageContent.GetValue());
            }
        }

        public async Task<SentMessage> GetCustomerPaymentMessageContent(CustomerPaymentMessage cp, TextParser parser)
        {
            return new SentMessage(cp.MessageContent, cp.ReceiverProvider.GetId());
        }

        public async Task<CustomerPaymentMessageBatch> CreateCustomerPaymentMessageBatch(int distributor, IEnumerable<int> providers, DateTime from, DateTime to, AppUser actor, SendCustomerPaymentEventCollection events)
        {
            //Calculate customer payments
            events?.OnPaymentCalculate?.Invoke(distributor, providers.ToArray(), from, to);
            var cusPayment = await GetCustomerPaymentMessage(distributor, providers, from, to);


            //Create batch
            var batch = await _messaging.CreateMessageBatch(actor);
            var parser = await _template.GetParserAsync<TextParser, CustomerPaymentMessageTemplate>();
            batch.SentMessages = new List<SentMessage>();
            var updateCP = new List<CustomerPayment>();
            foreach (var item in cusPayment)
            {
                if (item.CustomerPayment != null)
                {
                    var m = await GetCustomerPaymentMessageContent(item, parser);
                    m.MessageBatchId = batch.Id;
                    await _messaging.UpdateSentMessage(m);

                    item.CustomerPayment.SentMessage = m;
                    item.CustomerPayment.SentMessageId = m.Id;
                    batch.SentMessages.Add(m);
                    updateCP.Add(item.CustomerPayment);
                }
            }
            events?.OnPaymentCalculated?.Invoke(distributor, providers.ToArray(), from, to);
            //await _messaging.UpdateMessageBatch(batch);
            await BulkUpdateCustomerPayment(updateCP);

            var rs = new CustomerPaymentMessageBatch
            {
                Batch = batch,
                Entities = cusPayment.ToList()
            };
            return rs;
        }

        public async Task SendCustomerPaymentHangfire(IEnumerable<int> distributors, IEnumerable<int> providers, DateTime startDate, DateTime endDate, AppUser actor, PerformContext context)
        {
            var events = new SendCustomerPaymentEventCollection
            {
                OnPaymentSendStart = async (d, p, s, e) => await _service.SendPaymentProcessBegin(d, s, e, context),
                OnPaymentSendEnd = async (d, p, s, e) => await _service.SendPaymentProcessEnd(d, startDate, endDate, context),
                OnPaymentCalculate = async (d, p, s, e) => await _service.CalculatePayment(d, p, context),
                OnPaymentCalculated = async (d, p, s, e) => await _service.UpdateCustomerPaymentMessage(d, p, s, e, context),
                SendMessageBatchEvent = SendMessageBatchEventCollection.CreateProcessEvent(_sendMessageService, actor, context)

            };
            Func<Task> task = async () =>
            {
                foreach (var item in distributors)
                {
                    await SendCustomerPayment(item, providers, startDate, endDate, actor, events);
                }
            };

            await _processService.StartProcess(context, $"SEND CUSTOMER PAYMENT FROM {startDate} TO {endDate}", task, actor);
        }

        public async Task<CustomerPaymentMessageBatch> SendCustomerPayment(int item, IEnumerable<int> providers, DateTime startDate, DateTime endDate, AppUser actor, SendCustomerPaymentEventCollection events)
        {
            //await _service.SendPaymentProcessBegin(item, startDate, endDate, context);
            events?.OnPaymentSendStart?.Invoke(item, providers.ToArray(), startDate, endDate);
            var data = await CreateCustomerPaymentMessageBatch(item, providers, startDate, endDate, actor, events);
            var batch = await _messaging.SendMessageBatch(data.Batch.Id, actor, events?.SendMessageBatchEvent);
            events?.OnPaymentSendEnd?.Invoke(item, providers.ToArray(), startDate, endDate);
            data.Entities.ForEach(async u =>
            {
                if (u.CustomerPayment.SentMessageId == null)
                    return;
                u.CustomerPayment.SentMessage = await _messaging.GetSentMessageById(u.CustomerPayment.SentMessageId.Value);
            });
            return new CustomerPaymentMessageBatch
            {
                Batch = batch,
                Entities = data.Entities
            };
        }

        public async Task<IEnumerable<CustomerPayment>> GetCustomerPayment(GetListParams<CustomerPayment> param)
        {
            return await _rep.ListRaw(param);
        }

        public async Task<int> GetCustomerPaymentCount(GetListParams<CustomerPayment> param)
        {
            return await _rep.CountRaw(param);
        }
        #endregion
    }
}
