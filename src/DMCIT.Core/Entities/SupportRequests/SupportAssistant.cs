using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.SupportRequests
{
    public class SupportAssistant : BaseVersionControlEntity<SupportAssistant>
    {
        public int AssistantId { get; set; }
        public Employee Assistant { get; set; }
        public int SupportRequestId { get; set; }
        public SupportRequest SupportRequest { get; set; }

        public SupportAssistant() { }
        public SupportAssistant(int req, int assistant)
        {
            SupportRequestId = req;
            AssistantId = assistant;
        }
    }
}
