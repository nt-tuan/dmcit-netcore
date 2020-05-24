using DMCIT.Core.Entities.Processes;

namespace DMCIT.Core.Entities.DataSynchronize
{
    public class Diary131SynchronizeJob : BackgroundProcess
    {
        public Diary131SynchronizeJob() : base()
        {
        }

        public Diary131SynchronizeJob(int jobId) : base()
        {
            Id = jobId;
        }

        public Diary131SynchronizeJob(int jobId, string source, string name) : base()
        {
            Id = jobId;
            DistributorCode = source;
            Name = name;
        }
    }
}
