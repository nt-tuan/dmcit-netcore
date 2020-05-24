using DMCIT.Core.Entities.Core;

namespace DMCIT.Core.Entities.Processes
{
    public class SendMessageProcess : BackgroundProcess
    {
        public SendMessageProcess(int batchId, string jobId, AppUser actor) : base($"SEND MESSAGES {batchId} PROCESS", jobId, actor)
        {

        }
    }
}
