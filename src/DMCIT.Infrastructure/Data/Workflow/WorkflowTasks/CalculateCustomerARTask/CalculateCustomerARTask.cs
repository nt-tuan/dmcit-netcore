using DMCIT.Core.Entities;
using DMCIT.Core.Entities.Workflow;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Providers.Excel;
using DMCIT.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data.Workflow.WorkflowTasks.CalculateCustomerARTask
{
    public class CalculateCustomerARTask : WorkflowTask
    {
        private readonly ICustomerARRepository _rep;
        private readonly IDataCollectorRepository _collector;
        private readonly ISaleRepository _sale;
        private readonly ITemplateRepository _template;
        private readonly ISettingRepository _settingRep;
        private readonly WorkflowSetting _setting;
        private readonly GeneralSetting _general;
        public DateTime from { get; set; }
        public DateTime to { get; set; }
        public string ServerCode { get; set; }
        public int[] providers { get; set; }
        public CalculateCustomerARTask(int id, DefinedWorkflowTask xe, Workflow wf) : base(id, xe, wf)
        {
        }

        [ActivatorUtilitiesConstructor]
        public CalculateCustomerARTask(IWorkflowService service,
            ICustomerARRepository cus,
            IDataCollectorRepository collector,
            ISaleRepository sale,
            ITemplateRepository template,
            ISettingRepository settingRep,
            int id,
            DefinedWorkflowTask xe,
            WorkingWorkflow wf) : base(service, id, xe, wf)
        {
            _rep = cus;
            _collector = collector;
            _sale = sale;
            _template = template;
            _settingRep = settingRep;
            var store = settingRep.GetSettingStore();
            _setting = store.GetSetting<WorkflowSetting>();
            _general = store.GetSetting<GeneralSetting>();
        }



        private void init()
        {
            ServerCode = GetSetting("serverCode").Value;
            providers = GetSettingsInt("providers");
        }

        FileInf CreateFile(string filename, MemoryStream stream)
        {
            var path = Path.Combine(_setting.WorkflowsTempFolder, filename);
            var dirPath = Path.GetDirectoryName(path);
            var ext = Path.GetExtension(path);
            var withoutExt = Path.GetFileNameWithoutExtension(path) + "_" + DateTime.Now.ToString("ddmmyy");
            path = Path.Combine(dirPath, withoutExt + ext);
            int index = 0;

            while (File.Exists(path))
            {
                index++;
                path = Path.Combine(dirPath, withoutExt + $"_({index})" + ext);
            }
            using (var fs = File.Create(path))
            {
                stream.WriteTo(fs);
            }
            return new FileInf(path, Id);
        }
        private async Task<FileInf> calculatePayments(int d)
        {
            var customerPayments = (await _rep.CalculateCustomerPayments(d, from, to)).ToList();

            var headers = new[] { "CustomerCode", "DistributorCode", "Amount", "Liability", "ReceiptDate", "CreatedDate", "IsSent" };

            var stream = ExcelExporter.Export(customerPayments, headers, (item, sheet, index) =>
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

            return CreateFile("calculated_customer_payments.xlsx", stream);
        }
        private async Task<FileInf> sendPaymentMessges(int d)
        {
            var events = new SendCustomerPaymentEventCollection
            {
            };

            var pMessages = await _rep.SendCustomerPayment(d, providers, from, to, null, events);

            var mdata = pMessages.Entities.Select(u => new CustomerPaymentMessageModel(u)).ToList();

            var exporter = await _template.GetParserAsync<ExcelExporter, CustomerPaymentExcelExportModel>();

            var stream = await exporter.Parse(mdata);
            return CreateFile("customer_payments_messages.xlsx", stream);
        }
        protected override async Task<TaskStatus> _run()
        {
            try
            {
                init();
                if (Workflow.Parameters == null)
                    throw new Exception("This task required parameters");
                if (!Workflow.Parameters.ContainsKey("from"))
                {
                    throw new Exception("Required parameter {from}");
                }
                if (!Workflow.Parameters.ContainsKey("from"))
                {
                    throw new Exception("Required parameter {to}");
                }

                from = _general.ParseDateTime(Workflow.Parameters["from"]);
                to = _general.ParseDateTime(Workflow.Parameters["to"]);
                var d = await _sale.GetDistributorByCode(ServerCode);
                var calFile = await calculatePayments(d.GetId());
                var mesFile = await sendPaymentMessges(d.GetId());
                AddFileConcurrent(calFile);
                AddFileConcurrent(mesFile);
            }
            catch (Exception e)
            {
                Error(e);
                return new TaskStatus(Status.Failed, false);
            }
            return new TaskStatus(Status.Done, false);
        }
    }
}
