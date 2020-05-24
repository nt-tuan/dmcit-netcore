using DMCIT.Core.Entities.DataCollector;
using DMCIT.Core.SharedKernel;
using System;

namespace DMCIT.Core.Events
{
    public class LoadingDiary131Progress : BaseProgress
    {
        public DistributedServer Server { get; set; }
        public DateTime LoadStartTime { get; set; }
        public DateTime LoadEndTime { get; set; }

        public LoadingDiary131Progress(DistributedServer server, DateTime startTime, DateTime endTime) : base()
        {
            Server = server;
            LoadStartTime = startTime;
            LoadEndTime = endTime;
            Title = ToString();
        }

        public override void SetBegin()
        {
            base.SetBegin();
            SetDescription($"Initializing to download diary131 from #{Server.DistributorCode} ({Server.Servername}) from {LoadStartTime} to {LoadEndTime}");
        }

        public void SetDownLoad()
        {
            SetDescription($"Downloading diary131 from #{Server.DistributorCode} ({Server.Servername})");
        }
        public void SetUpdate()
        {
            SetDescription($"Updating diary131 from #{Server.DistributorCode} ({Server.Servername})");
        }
        public void SetDelete()
        {
            SetDescription($"Clear old data #{Server.DistributorCode} ({Server.Servername})");
        }

        public override string ToString()
        {
            return $"download diary131 from {Server.ToString()} from {LoadStartTime} before {LoadEndTime}";
        }
    }
}
