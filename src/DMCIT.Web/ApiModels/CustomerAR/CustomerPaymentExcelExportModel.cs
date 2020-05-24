using DMCIT.Core.Entities.Templates;
using DMCIT.Infrastructure.Providers;
using DMCIT.Infrastructure.Providers.Excel;

namespace DMCIT.Web.ApiModels.CustomerAR
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
            var description = "Customer payment SMS Content Template";
            var template = base.Default();
            template.Description = description;
            return template;
        }
    }
}
