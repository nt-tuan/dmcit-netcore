using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.DataSynchronize;
using DMCIT.Core.Entities.Processes;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public interface IJobTrackingRepository
    {
        Task<T> GetRunningJob<T>(int jobId) where T : BackgroundProcess;
        Task<Diary131SynchronizeJob> GetOrAddRunningCollectingJob(int jobId, string source, string name, AppUser actor);
        Task<SendingMessageJob> GetOrAddRunningMessagingJob(int jobId, string source, string name, AppUser actor);
        Task<BackgroundProcess> StartJob(string jobId, AppUser actor);
        Task<T> AddRunningJob<T>(T entity, AppUser actor) where T : BackgroundProcess;
        Task<T> StopRunningJob<T>(int jobId, string status, string response, AppUser actor) where T : BackgroundProcess;
    }
}
