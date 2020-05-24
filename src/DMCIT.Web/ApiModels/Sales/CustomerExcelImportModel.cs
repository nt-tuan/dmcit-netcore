using DMCIT.Core.Entities.Templates;
using DMCIT.Infrastructure.Providers.Excel;

namespace DMCIT.Web.ApiModels.Sales
{
    public class CustomerExcelImportModel :
        ExcelImporterOption<CustomerModel>
    {
        public override Template Default()
        {
            firstRow = 0;
            firstColumn = 0;
            headerRowCount = 3;
            filePath = "AppData\\Templates\\Customer_Data_Template.xlsx";
            maxRow = 5000;
            var template = base.Default();
            template.Description = "Customer excel import template";
            return template;
        }
    }
}
