using DMCIT.Core.Entities.Accounting;
using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.DataCollector;
using DMCIT.Core.SharedKernel;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public class LoadDiary131EventCollection
    {
        public Action<DistributedServer, DateTime, DateTime> OnBeginDownloadDiary131FromServer { get; set; }
        public Action OnDownloadingDiary131FromServer { get; set; }
        public Action OnUpdatingDiary131FromServer { get; set; }
        public Action OnEndDownloadDiaryFromServer { get; set; }
        public Func<Task> OnFinish { get; set; }
    }
    public interface IDataCollectorRepository
    {
        Task<ICollection<Diary131>> GetDiary131(GetListParams<Diary131> p);
        Task LoadDiary131s(AppUser actor, LoadDiary131EventCollection events);
        Task LoadDiary131s(DateTime start, DateTime end, AppUser actor, PerformContext context);

        /// <summary>
        /// Download all diary131 until now
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        Task LoadDiary131sProcess(AppUser actor, PerformContext context);
        Task<List<DistributedServer>> GetDistributedServer(string code);
        Task<DistributedServer> GetDistributedServer(string code, DateTime startTime, DateTime endTime);
        Task<ICollection<DistributedServer>> GetDistributedServers(GetListParams<DistributedServer> param = null);
        Task<ICollection<DistributedServer>> GetDistributedServersWithDetail();
        Task UpdateDistributedServer(DistributedServer server, AppUser actor);
        Task AddDistributedServer(DistributedServer server, AppUser actor);
        Task DeleteDistributedServer(DistributedServer server, AppUser actor);
    }
}
