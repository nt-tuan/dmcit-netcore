using DMCIT.Core.Entities.Templates;
using DMCIT.Infrastructure.Providers;
using DMCIT.Infrastructure.Providers.Excel;
using System.Collections.Generic;

namespace DMCIT.Web.ApiModels.Sales
{
    public class CustomerExcelExportModel : ExcelExporterOption
    {
        public ICollection<CustomerModel> Data { get; set; }

        public override IExcelExportableObject CreateArgument()
        {
            return new InvalidableModel<CustomerModel>();
        }

        public override Template Default()
        {
            firstRow = 0;
            headerRowCount = 2;
            sheetIndex = 0;
            sheetName = "Customer";
            firstColumn = 0;
            filePath = "AppData\\Templates\\Customer_Data_Template.xlsx";
            var template = base.Default();
            template.Description = "Customer Data Template";
            return template;
        }
    }
}
