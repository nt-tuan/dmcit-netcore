using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Entities.Processes;

namespace DMCIT.Core.Entities.DataSynchronize
{
    public class SendingMessageJob : BackgroundProcess
    {
        public static readonly string PREFIX = "SENDINGMESSAGEJOB-";
        public static string GetId(int batchId)
        {
            return PREFIX + batchId.ToString();
        }
        public int BatchId { get; set; }
        public MessageBatch MessageBatch { get; set; }

        public SendingMessageJob() : base()
        {
            //JobId = nameof(SendingMessageJob);
        }

        public SendingMessageJob(string jobId) : base()
        {

        }

        public SendingMessageJob(int batchId)
        {
            BatchId = batchId;
        }
    }
}
