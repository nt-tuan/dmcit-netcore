using DMCIT.Core.Entities.DataCollector;
using System;

namespace DMCIT.Infrastructure.Data.Exceptions.DataCollector
{
    public class FailedToLoadDiary131Exception : BaseExceptionInformation
    {
        public DistributedServer server { get; set; }
        public FailedToLoadDiary131Exception() : base()
        {

        }

        public FailedToLoadDiary131Exception(DistributedServer server) : this()
        {
            this.server = server;
        }

        public override Exception ToException()
        {
            return new Exception($"Failed to load Diary131 from {server.DistributorCode}");
        }
    }
}
