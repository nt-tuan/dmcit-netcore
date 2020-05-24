using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Workflow;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data.Workflow.SQLServer
{
    public class WorkflowRepository : IWorkflowRepository
    {
        private readonly AppDbContext _db;
        private readonly IRepository _rep;
        private readonly UserManager<AppUser> _user;
        public WorkflowRepository(AppDbContext db, IRepository rep, UserManager<AppUser> user)
        {
            _db = db;
            _rep = rep;
            _user = user;
        }

        public async Task Init()
        {
            // StatusCount
            await ClearStatusCount();

            var statusCount = new StatusCount
            {
                PendingCount = 0,
                RunningCount = 0,
                DoneCount = 0,
                FailedCount = 0,
                WarningCount = 0,
                DisabledCount = 0,
                StoppedCount = 0
            };

            //TODO: Add init status count
            _db.Set<StatusCount>().Add(statusCount);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> CheckUserWorkflow(string userId, int workflowId)
        {
            return await _db.Set<UserWorkflow>().Where(u => u.AppUserId == userId && u.DefinedWorkflowId == workflowId).AnyAsync();
        }

        public async Task ClearStatusCount()
        {
            var e = await _db.Set<StatusCount>().ToListAsync();
            _db.RemoveRange(e);
            await _db.SaveChangesAsync();
        }

        public async Task DecrementPendingCount()
        {
            var e = await _db.Set<StatusCount>().FirstOrDefaultAsync();
            e.PendingCount--;
            _db.Update(e);
            await _db.SaveChangesAsync();
        }

        public async Task DecrementRunningCount()
        {
            var e = await _db.Set<StatusCount>().FirstOrDefaultAsync();
            e.RunningCount--;
            _db.Update(e);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUserWorkflowRelationsByUserId(string userId)
        {
            var userflow = await _db.Set<UserWorkflow>().Where(u => u.AppUserId == userId).ToListAsync();
            _db.RemoveRange(userflow);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteUserWorkflowRelationsByWorkflowId(int workflowDbId)
        {
            var userflow = await _db.Set<UserWorkflow>().Where(u => u.DefinedWorkflowId == workflowDbId).ToListAsync();
            _db.RemoveRange(userflow);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteWorkflow(int id)
        {
            var e = await _db.Set<DefinedWorkflow>().Where(u => u.Id == id).FirstOrDefaultAsync();
            await _rep.Delete(e);
        }

        public async Task DeleteWorkflows(int[] ids)
        {
            foreach (var item in ids)
            {
                await DeleteWorkflow(item);
            }
        }

        public async Task<IEnumerable<WorkflowEntry>> GetEntries()
        {
            return await _rep.List<WorkflowEntry>(null);
        }

        public async Task<IEnumerable<WorkflowEntry>> GetEntries(GetListParams<WorkflowEntry> par)
        {
            return await _rep.List<WorkflowEntry>(par);
        }

        public async Task<int> GetEntriesCount(GetListParams<WorkflowEntry> par)
        {
            return await _rep.Count(par);
        }

        public async Task<WorkflowEntry> GetEntry(int workflowId)
        {
            var e = await _db.Set<WorkflowEntry>().Where(u => u.DefinedWorkflowId == workflowId).FirstOrDefaultAsync();
            return e;
        }

        public async Task<DateTime> GetEntryStatusDateMax()
        {
            var e = await _db.Set<WorkflowEntry>().OrderByDescending(u => u.StatusDate).FirstOrDefaultAsync();
            return e?.StatusDate ?? DateTime.Now;
        }

        public async Task<DateTime> GetEntryStatusDateMin()
        {
            var e = await _db.Set<WorkflowEntry>().OrderBy(u => u.StatusDate).FirstOrDefaultAsync();
            return e?.StatusDate ?? DateTime.Now;
        }

        public async Task<HistoryWorkflowEntry> GetHistoryWorkflowEntry(int id)
        {
            return await _rep.GetById<HistoryWorkflowEntry>(id);
        }

        public async Task<IEnumerable<HistoryWorkflowEntry>> GetHistoryEntries()
        {
            return await _rep.List<HistoryWorkflowEntry>(null);
        }

        public async Task<IEnumerable<HistoryWorkflowEntry>> GetHistoryEntries(GetListParams<HistoryWorkflowEntry> par)
        {
            return await _rep.List(par);
        }

        public async Task<int> GetHistoryEntriesCount(GetListParams<HistoryWorkflowEntry> par)
        {
            return await _rep.Count(par);
        }

        public async Task<DateTime> GetHistoryEntryStatusDateMax()
        {
            var e = await _db.Set<HistoryWorkflowEntry>().OrderByDescending(u => u.StatusDate).FirstOrDefaultAsync();
            return e?.StatusDate ?? DateTime.Now;
        }

        public async Task<DateTime> GetHistoryEntryStatusDateMin()
        {
            var e = await _db.Set<HistoryWorkflowEntry>().OrderBy(u => u.StatusDate).FirstOrDefaultAsync();
            return e?.StatusDate ?? DateTime.Now;
        }

        public async Task<StatusCount> GetStatusCount()
        {
            return await _db.Set<StatusCount>().AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<int>> GetUserWorkflows(string userId)
        {
            return await _db.Set<UserWorkflow>().Where(u => u.AppUserId == userId).Select(u => u.DefinedWorkflowId).ToListAsync();
        }

        public async Task<DefinedWorkflow> GetWorkflow(int id)
        {
            Func<IQueryable<DefinedWorkflow>, IQueryable<DefinedWorkflow>> func = query => query.Include(u => u.UserWorkflows).ThenInclude(u => u.AppUser);
            return await _rep.GetById<DefinedWorkflow>(id, func);
        }

        public async Task<IEnumerable<DefinedWorkflow>> GetWorkflows(GetListParams<DefinedWorkflow> par)
        {
            return await _rep.List(par);
        }

        public async Task IncrementDisabledCount()
        {
            var s = await GetStatusCount();
            s.DisabledCount++;
            _db.Update(s);
            await _db.SaveChangesAsync();
        }

        public async Task IncrementDisapprovedCount()
        {
            var s = await GetStatusCount();
            s.DisapprovedCount++;
            _db.Update(s);
            await _db.SaveChangesAsync();
        }

        public async Task IncrementDoneCount()
        {
            var s = await GetStatusCount();
            s.DoneCount++;
            _db.Update(s);
            await _db.SaveChangesAsync();
        }

        public async Task IncrementFailedCount()
        {
            var s = await GetStatusCount();
            s.FailedCount++;
            _db.Update(s);
            await _db.SaveChangesAsync();
        }

        public async Task IncrementPendingCount()
        {
            var s = await GetStatusCount();
            s.PendingCount++;
            _db.Update(s);
            await _db.SaveChangesAsync();
        }

        public async Task IncrementRunningCount()
        {
            var s = await GetStatusCount();
            s.RunningCount++;
            _db.Update(s);
            await _db.SaveChangesAsync();
        }

        public async Task IncrementStoppedCount()
        {
            var s = await GetStatusCount();
            s.StoppedCount++;
            _db.Update(s);
            await _db.SaveChangesAsync();
        }

        public async Task IncrementWarningCount()
        {
            var s = await GetStatusCount();
            s.WarningCount++;
            _db.Update(s);
            await _db.SaveChangesAsync();
        }

        public async Task InsertEntry(WorkflowEntry entry)
        {
            await _rep.Add(entry);
        }

        public async Task InsertHistoryEntry(HistoryWorkflowEntry entry)
        {
            await _rep.Add(entry);
        }

        public async Task InsertUserWorkflowRelation(UserWorkflow userWorkflow)
        {
            await _rep.Add(userWorkflow);
        }

        public async Task<int> InsertWorkflow(DefinedWorkflow workflow, AppUser actor)
        {
            var userWf = workflow.UserWorkflows;
            workflow.UserWorkflows = null;
            var e = await _rep.Add(workflow, actor);
            await SetUserWorkflows(workflow.Id, userWf.Select(u => u.AppUserId).ToHashSet());
            return e.Id;
        }

        public async Task UpdateEntry(WorkflowEntry entry)
        {
            await _rep.Update(entry);
        }

        public async Task UpdateWorkflow(DefinedWorkflow workflow, AppUser actor)
        {
            var userWf = workflow.UserWorkflows;
            workflow.UserWorkflows = null;
            await _rep.Update(workflow, actor);
            await SetUserWorkflows(workflow.Id, userWf.Select(u => u.AppUserId).ToHashSet());
        }

        public async Task<string> GetEntryLogs(int entryId)
        {
            var e = await _rep.GetById<WorkflowEntry>(entryId);
            return e?.Logs;
        }

        public async Task<string> GetHistoryEntryLogs(int entryId)
        {
            var e = await _rep.GetById<HistoryWorkflowEntry>(entryId);
            return e?.Logs;
        }

        public async Task ClearEntries()
        {
            var e = await _db.Set<WorkflowEntry>().ToListAsync();
            _db.RemoveRange(e);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<DefinedWorkflow>> GetWorkflows()
        {
            var param = new GetListParams<DefinedWorkflow>();
            param.extension = query => query
                .Include(u => u.UserWorkflows)
                .ThenInclude(u => u.AppUser);

            return (await _rep.List(param)).ToArray();
        }

        public async Task SetUserWorkflows(int workflowId, HashSet<string> users)
        {
            var uw = await _db.UserWorkflows.Where(u => u.DefinedWorkflowId == workflowId).ToListAsync();
            _db.RemoveRange(uw);
            await _db.SaveChangesAsync();
            if (users == null)
                return;
            var newEntities = new List<UserWorkflow>();
            foreach (var item in users)
            {
                var e = await _user.FindByIdAsync(item);
                if (e != null)
                    newEntities.Add(new UserWorkflow { DefinedWorkflowId = workflowId, AppUserId = e.Id });
            }

            if (newEntities.Count > 0)
            {
                await _db.AddRangeAsync(newEntities);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<UserWorkflow>> GetUserWorkflows(int workflowId)
        {
            return await _db.UserWorkflows.Where(u => u.DefinedWorkflowId == workflowId).ToListAsync();
        }
    }
}
