using DMCIT.Core.Entities.Templates;
using DMCIT.Infrastructure.Providers;
using DMCIT.Infrastructure.Providers.Excel;

namespace DMCIT.Web.ApiModels.Messaging.Recipient
{
    public class RecipientExcelExportModel :
        ExcelExporterOption
    {
        public override IExcelExportableObject CreateArgument()
        {
            return new MessageReceiverModel();
        }

        public override Template Default()
        {
            var template = base.Default();
            template.Description = "Export recipients with excel format";
            return template;
        }
    }
}
