
using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.DataSynchronize;
using DMCIT.Core.Entities.Processes;
using DMCIT.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class JobTrackingRepository : IJobTrackingRepository
    {
        readonly AppDbContext _db;
        readonly IRepository _res;

        public JobTrackingRepository(AppDbContext context, IRepository res)
        {
            _db = context;
            _res = res;
        }

        public async Task<T> AddRunningJob<T>(T entity, AppUser actor) where T : BackgroundProcess
        {
            entity.CreatedById = actor != null ? actor.Id : null;
            var added = await _res.Add(entity);
            return added;
        }

        public async Task<BackgroundProcess> StartJob(string jobId, AppUser actor)
        {
            var process = await _db.Set<BackgroundProcess>().AsNoTracking().Where(u => u.JobId == jobId).FirstOrDefaultAsync();

            if (process.Status == BackgroundProcess.PENDING)
            {
                process.Status = BackgroundProcess.BEGIN_PROCESS;
                await _res.Update(process, actor);
                return process;
            }

            //TODO: BackgroundProcess is not in PENDING STATE
            throw new Exception("Invalid BackgroundProcess");
        }

        public async Task<T> GetRunningJob<T>(int id) where T : BackgroundProcess
        {
            var query = _db.Set<T>().Include(u => u.CreatedBy).AsNoTracking().Where(u => u.EndTime == null && u.Id == id);
            var entity = await query.FirstOrDefaultAsync();
            return entity;
        }

        public async Task<T> StopRunningJob<T>(int code, string status, string response, AppUser actor) where T : BackgroundProcess
        {
            var entity = await GetRunningJob<T>(code);
            if (entity != null)
            {
                entity.EndTime = DateTime.Now;
                entity.Status = status;
                entity.Response = response;
                await _res.Update(entity);
            }
            return entity;
        }

        public async Task<Diary131SynchronizeJob> GetOrAddRunningCollectingJob(int id, string source, string name, AppUser actor)
        {
            var jobTracking = await GetRunningJob<Diary131SynchronizeJob>(id);
            if (jobTracking == null)
            {
                jobTracking = new Diary131SynchronizeJob(id, source, name);
                jobTracking = await AddRunningJob(jobTracking, actor);
                if (jobTracking == null)
                    throw new Exception("CAN NOT INIT TRACKING OBJECT");
            }
            return jobTracking;
        }

        public async Task<SendingMessageJob> GetOrAddRunningMessagingJob(int jobId, string source, string name, AppUser actor)
        {
            var jobTracking = await GetRunningJob<SendingMessageJob>(jobId);

            if (jobTracking == null)
            {
                jobTracking = new SendingMessageJob(jobId);
                jobTracking = await AddRunningJob(jobTracking, actor);
                if (jobTracking == null)
                    throw new Exception("CAN NOT INIT TRACKING OBJECT");
            }
            return jobTracking;
        }
    }
}
