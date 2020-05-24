using DMCIT.Core.Entities.Templates;
using DMCIT.Infrastructure.Providers.Excel;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class ReceiverExcelImportModel : ExcelImporterOption<InvalidableModel<MessageReceiverModel>>
    {
        public override Template Default()
        {
            firstRow = 0;
            headerRowCount = 2;
            firstColumn = 0;
            filePath = "AppData\\Templates\\Receiver_Import_Template";
            var template = base.Default();
            template.Description = "Import receiver excel template";
            return template;
        }
    }
}
