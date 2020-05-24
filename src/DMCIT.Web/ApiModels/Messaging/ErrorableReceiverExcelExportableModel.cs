using DMCIT.Core.Entities.Templates;
using DMCIT.Infrastructure.Providers;
using DMCIT.Infrastructure.Providers.Excel;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class ErrorableReceiverExcelExportableModel : ExcelExporterOption
    {
        public override IExcelExportableObject CreateArgument()
        {
            return new InvalidableModel<MessageReceiverModel>();
        }

        public override Template Default()
        {
            firstRow = 0;
            headerRowCount = 3;
            sheetIndex = 0;
            sheetName = "Recipients";
            firstColumn = 0;
            filePath = "AppData\\Templates\\Receiver_Export_Template.xlsx";

            var template = base.Default();
            template.Description = "Recipient Data Template";
            return template;
        }
    }
}
