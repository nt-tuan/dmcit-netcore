using DMCIT.Core.Entities.Templates;
using DMCIT.Infrastructure.Providers;
using DMCIT.Infrastructure.Providers.Excel;
using System.Collections.Generic;

namespace DMCIT.Infrastructure.Data.Workflow.WorkflowTasks.CalculateCustomerARTask
{
    public class CustomerPaymentExcelExportModel :
        ExcelExporterOption
    {
        public override IExcelExportableObject CreateArgument()
        {
            return new CustomerPaymentMessageModel();
        }

        public override Template Default()
        {
            firstColumn = 0;
            firstRow = 0;
            headerRowCount = 1;
            sheetIndex = 0;
            sheetName = "Payments";
            filePath = "AppData\\Templates\\Customer_Payment_Template.xlsx";
            columnMapper = new Dictionary<string, string>();
            columnMapper.Add("NGAY CT", "receiptdate");
            columnMapper.Add("TEN TAT", "customername");
            columnMapper.Add("SDT", "addressee");
            columnMapper.Add("THANH TOAN", "payment");
            columnMapper.Add("TON NO", "aramount");
            columnMapper.Add("NGAY GUI", "senttime");
            columnMapper.Add("MACN", "distributorcode");
            columnMapper.Add("TIN NHAN", "message");
            columnMapper.Add("KET QUA", "messageresult");
            var description = "Customer payment SMS Content Template";
            var template = base.Default();
            template.Description = description;
            return template;
        }
    }
}
