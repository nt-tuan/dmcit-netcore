using DMCIT.Core.Entities.Core;

namespace DMCIT.Core.Entities.Processes
{
    public class LoadDiary131sProcess : BackgroundProcess
    {
        public static string ProcessName = "LOAD DIARY131 FROM DISTRIBUTED SERVERS";
        public LoadDiary131sProcess(string jobId, AppUser actor) : base(ProcessName, jobId, actor) { }
    }
}
