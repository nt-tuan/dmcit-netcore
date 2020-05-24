using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging.TemplateMessage;
using DMCIT.Core.Entities.Reports;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Providers.Excel;
using DMCIT.Infrastructure.Services;
using DMCIT.Utility;
using DMCIT.Web.ApiModels;
using DMCIT.Web.ApiModels.CustomerAR;
using DMCIT.Web.ApiModels.Messaging;
using DMCIT.Web.ApiModels.Sales;
using DMCIT.Web.Filters;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMCIT.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    [Authorize]
    public class CustomerARController : ControllerBase
    {
        private ICustomerARRepository _customerAR;
        private ICoreRepository _core;
        private ISaleRepository _sale;
        private ITemplateRepository _template;
        private UserManager<AppUser> _userManager;
        private IProcessManagerService _processService;
        public CustomerARController(ICustomerARRepository customerAR, ICoreRepository core, ISaleRepository sale, ITemplateRepository template, UserManager<AppUser> userManager,
            IProcessManagerService processService)
        {
            _customerAR = customerAR;
            _core = core;
            _userManager = userManager;
            _sale = sale;
            _template = template;
            _processService = processService;
        }


        [HttpPost("GetDiary131State")]
        public async Task<IActionResult> GetLastDiary131()
        {
            var servers = await _core.GetDistributedServers();

            var data = new List<Diary131State>();
            foreach (var item in servers)
            {
                var temp = new Diary131State
                {
                    name = item.Servername,
                    code = item.DistributorCode
                };
                var record = await _core.GetLastDiary131(item.DistributorCode);
                if (record != null)
                    temp.lastRecord = record.ReceiptDate;
                var lastPayment = await _customerAR.GetLastCustomerPayment(item.DistributorCode);
                if (lastPayment != null)
                    temp.lastPayment = lastPayment.ReceiptDate;
                data.Add(temp);
            }

            return Ok(new { data });
        }

        [HttpPost("GetCustomerLiability")]
        public async Task<IActionResult> getReceiverLiability(TableParameter param)
        {
            //DISABLE FOR TESTING NEW DESGIN
            //var pE = param.ToCustomerLiabilityParam();
            var pE = param.ToEntityParam<CustomerARNow>();
            var data = await _customerAR.GetStoredCustomerAR(pE);
            var count = await _customerAR.GetStoredCustomerARCount(pE);
            return Ok(new BaseListModel<CustomerARModel>(data.Select(u => new CustomerARModel(u)).ToList(), param.page, param.pageSize, count));
        }

        [HttpPost("ExportCustomersPayment")]
        public async Task<IActionResult> ExportCustomersPayment(GetCustomerPaymentModel model)
        {
            var data = new List<CustomerPaymentMessage>();

            foreach (var d in model.distributors)
            {
                data.AddRange(await _customerAR.GetCustomerPaymentMessage(d, model.providers, model.startDate, model.endDate));
            }

            //var setting = _setting.GetSettingStore();

            var mdata = data.Select(u => new CustomerPaymentMessageModel(u)).ToList();

            var exporter = await _template.GetParserAsync<ExcelExporter, CustomerPaymentExcelExportModel>();
            //TODO: Temperory code, move this part to settings
            var stream = await exporter.Parse(mdata);
            return File(stream.GetBuffer(), "application/octet-stream", "review.xlsx");
            //write item to excel
        }

        [HttpPost("CalculateCustomersPayment")]
        public async Task<IActionResult> CalculateCustomersPayment(GetCustomerPaymentModel model)
        {
            var data = new List<CustomerPayment>();

            foreach (var item in model.distributors)
            {
                var distributor = await _sale.GetDistributorById(item);
                data.AddRange(await _customerAR.CalculateCustomerPayments(distributor.GetId(), model.startDate, model.endDate));
            }
            var headers = new[] { "CustomerCode", "DistributorCode", "Amount", "Liability", "ReceiptDate", "CreatedDate", "IsSent" };
            var stream = FileHelper.ToExcelFile(data, headers, (item, sheet, index) =>
            {
                var row = sheet.CreateRow(index);
                row.CreateCell(0).SetCellValue(item.CustomerCode);
                row.CreateCell(1).SetCellValue(item.DistributorCode);
                row.CreateCell(2).SetCellValue((double)item.Amount);
                if (item.ARAmount == null)
                {
                    row.CreateCell(3).SetCellValue("-");
                }
                else
                {
                    row.CreateCell(3).SetCellValue((double)item.ARAmount);
                }
                row.CreateCell(4).SetCellValue(item.ReceiptDate);
                if (item.DateCreated != null)
                    row.CreateCell(5).SetCellValue(item.DateCreated.Value);
                else
                    row.CreateCell(5).SetCellType(NPOI.SS.UserModel.CellType.Blank);
                row.CreateCell(6).SetCellValue(item.SentMessageId == null ? "None" : "Done");
            });
            return File(stream.GetBuffer(), "application/octet-stream", "review.xlsx");
        }

        [HttpPost("SendCustomersPayment")]
        public async Task<string> SendCustomersPayment(GetCustomerPaymentModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var job = BackgroundJob.Enqueue<ICustomerARRepository>(u => u.SendCustomerPaymentHangfire(model.distributors, model.providers, model.startDate, model.endDate, user, null));
            await _processService.RegisterProcess(job, $"SEND CUSTOMER PAYMENT FROM {model.startDate} TO {model.endDate}", user);
            return job;
        }

        [HttpPost("ExportCustomerLiabilities")]
        public async Task<IActionResult> ExportCustomerLiabilities(SendCustomerLiabilityMessageModel model)
        {
            if (model == null)
                return NotFound();
            //var builder = new MessageBuilder();
            //var data = await builder.GetCustomerLiability(model, _imessage, _sale, _setting, _config);
            var data = (await _customerAR.GetCustomerARMessages(model.distributors, model.providers, DateTime.Now)).Select(u => new CustomerARMessageModel(u));

            var parser = await _template.GetParserAsync<ExcelExporter, CustomerARMessageExcelExportModel>();
            var stream = await parser.Parse(data);

            return File(stream.GetBuffer(), "application/octet-stream", $"cutomer-liability-{DateTime.Now.ToString("dd-MM-yyyy")}.xlsx");
        }

        [HttpPost("SendCustomerLiabilityMessages")]
        public async Task<IActionResult> SendCustomerLiabilityMessages(SendCustomerLiabilityMessageModel model)
        {
            if (model == null)
                return NotFound();
            var data = await _customerAR.CalculateCustomerARs(model.distributors, DateTime.Now);

            foreach (var item in data)
            {

            }
            return Ok();
        }

        [HttpPost]
        [Route("payments")]
        public async Task<ActionResult<BaseListModel<CustomerPaymentModel>>> GetPayments(TableParameter<CustomerPaymentFilterModel, CustomerPayment> model)
        {
            var param = model.ToEntityParam();
            var rs = await _customerAR.GetCustomerPayment(param);
            var count = await _customerAR.GetCustomerPaymentCount(param);
            return new BaseListModel<CustomerPaymentModel>(rs.Select(u => new CustomerPaymentModel(u)).ToList(), model.page, model.pageSize, count);
        }

        [HttpPost]
        [Route("payments/excel")]
        public async Task<ActionResult> GetExcelPayments(TableParameter<CustomerPaymentFilterModel, CustomerPayment> model)
        {
            var param = model.ToEntityParam();
            param.page = null;
            param.pageRows = null;
            var rs = (await _customerAR.GetCustomerPayment(param)).Select(u => new CustomerPaymentModel(u)).ToList();

            //var count = await _customerAR.GetCustomerPaymentCount(param);
            var exporter = new ExcelExporter();
            var stream = await exporter.Parse(rs);
            return File(stream.GetBuffer(), "application/octet-stream", "customer_payments.xlsx");
        }

        [HttpPost]
        [Route("ars")]
        public async Task<ActionResult<BaseListModel<CustomerARModel>>> GetAR(TableParameter<CustomerARFilterModel, CustomerARNow> model)
        {
            var param = model.ToEntityParam();
            var rs = await _customerAR.GetStoredCustomerAR(param);
            var count = await _customerAR.GetStoredCustomerARCount(param);
            return new BaseListModel<CustomerARModel>(rs.Select(u => new CustomerARModel(u)), model.page, model.pageSize, count);
        }

        [HttpPost]
        [Route("ars/excel")]
        public async Task<ActionResult> GetExportARs(TableParameter<CustomerARFilterModel, CustomerARNow> model)
        {
            var param = model.ToEntityParam();
            var rs = (await _customerAR.GetStoredCustomerAR(param)).Select(u => new CustomerARModel(u)).ToList();
            var exporter = new ExcelExporter();
            var stream = await exporter.Parse(rs);
            return File(stream.GetBuffer(), "application/octet-stream", "customer_ars.xlsx");
        }
    }
}
