using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Entities.Messaging.TemplateMessage;
using DMCIT.Core.Entities.Reports;
using DMCIT.Core.Entities.Templates.TextParser;
using DMCIT.Core.SharedKernel;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public class SendCustomerPaymentEventCollection
    {
        public Action<int, int[], DateTime, DateTime> OnPaymentSendStart;
        public Action<int, int[], DateTime, DateTime> OnPaymentSendEnd;
        public Action<int, int[], DateTime, DateTime> OnPaymentCalculate { get; set; }
        public Action<int, int[], DateTime, DateTime> OnPaymentCalculated { get; set; }
        public SendMessageBatchEventCollection SendMessageBatchEvent { get; set; }
    }

    public interface ICustomerARRepository
    {
        #region PAYMENTS
        Task<IEnumerable<CustomerPayment>> GetCustomerPayment(GetListParams<CustomerPayment> param);
        Task<int> GetCustomerPaymentCount(GetListParams<CustomerPayment> param);
        Task<IEnumerable<CustomerPayment>> CalculateCustomerPayments(int distributor, DateTime from, DateTime to);
        Task<IEnumerable<CustomerPaymentMessage>> GetCustomerPaymentMessage(int distributor, IEnumerable<int> providers, DateTime from, DateTime to);
        Task<CustomerPaymentMessageBatch> CreateCustomerPaymentMessageBatch(int distributors, IEnumerable<int> providers, DateTime from, DateTime to, AppUser actor, SendCustomerPaymentEventCollection events);
        Task<SentMessage> GetCustomerPaymentMessageContent(CustomerPaymentMessage entity, TextParser parser);
        Task SendCustomerPaymentHangfire(IEnumerable<int> distributors, IEnumerable<int> providers, DateTime startDate, DateTime endDate, AppUser actor, PerformContext context);
        Task<CustomerPaymentMessageBatch> SendCustomerPayment(int distributor, IEnumerable<int> providers, DateTime startDate, DateTime endDate, AppUser actor, SendCustomerPaymentEventCollection events);
        Task<CustomerPayment> GetLastCustomerPayment(string code);
        #endregion

        #region AR
        /// <summary>
        /// Calculate all AR of customers
        /// </summary>
        /// <param name="to"></param>
        /// <returns></returns>
        Task<IEnumerable<CalculatedCustomerLiabilityQuery>> CalculateCustomerARs(DateTime to);

        /// <summary>
        /// Calculate AR of customers in specific distributors at a certain time
        /// </summary>
        /// <param name="distributors"></param>
        /// <param name="at"></param>
        /// <returns></returns>
        Task<IEnumerable<CalculatedCustomerLiabilityQuery>> CalculateCustomerARs(IEnumerable<int> distributors, DateTime at);

        /// <summary>
        /// Update AR of a customer at the end of an accounting period
        /// </summary>
        /// <param name="ap"></param>
        /// <param name="actor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        Task UpdateCustomerARs(AccountingPeriod ap, AppUser actor, PerformContext context);

        /// <summary>
        /// Get AR of a customer and his repicient address
        /// </summary>
        /// <param name="distributor"></param>
        /// <param name="providers"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        Task<IEnumerable<CustomerARMessage>> GetCustomerARMessages(IEnumerable<int> distributor, IEnumerable<int> providers, DateTime to);

        /// <summary>
        /// Get message content to report AR to a customer
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<SentMessage> GetCustomerARMessageContent(CustomerARMessage entity);
        Task SendCustomerAR(IEnumerable<int> distributors, IEnumerable<int> providers, DateTime endDate, AppUser actor, PerformContext context);

        Task<IEnumerable<CustomerARNow>> GetStoredCustomerAR(GetListParams<CustomerARNow> p);
        Task<int> GetStoredCustomerARCount(GetListParams<CustomerARNow> p);
        Task BulkUpdateCustomerPayment(IEnumerable<CustomerPayment> customerPayment);
        #endregion
    }
}
