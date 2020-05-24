using DMCIT.Core.Entities.Templates;
using DMCIT.Infrastructure.Providers;
using DMCIT.Infrastructure.Providers.Excel;

namespace DMCIT.Web.ApiModels.CustomerAR
{
    public class CustomerARMessageExcelExportModel : ExcelExporterOption
    {
        public CustomerARMessageExcelExportModel()
        {
        }

        public override IExcelExportableObject CreateArgument()
        {
            return new CustomerARMessageModel();
        }

        public override Template Default()
        {
            firstRow = 0;
            headerRowCount = 3;
            sheetIndex = 0;
            sheetName = "Customer";
            firstColumn = 0;
            filePath = "AppData\\Templates\\Customer_AR_Template.xlsx";
            var description = "Customer AR SMS Content Template";
            var template = base.Default();
            template.Description = description;
            return template;
        }
    }
}
