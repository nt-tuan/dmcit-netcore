using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Workflow;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public interface IWorkflowRepository
    {
        Task Init();
        Task<int> InsertWorkflow(DefinedWorkflow workflow, AppUser actor);
        Task<DefinedWorkflow> GetWorkflow(int id);
        Task<IEnumerable<DefinedWorkflow>> GetWorkflows();
        Task<IEnumerable<DefinedWorkflow>> GetWorkflows(GetListParams<DefinedWorkflow> p);
        Task<IEnumerable<UserWorkflow>> GetUserWorkflows(int workflowId);
        Task UpdateWorkflow(DefinedWorkflow workflow, AppUser actor);
        Task DeleteWorkflow(int id);
        Task DeleteUserWorkflowRelationsByWorkflowId(int workflowDbId);
        Task DeleteWorkflows(int[] ids);
        Task InsertUserWorkflowRelation(UserWorkflow userWorkflow);
        Task SetUserWorkflows(int workflowId, HashSet<string> users);
        Task DeleteUserWorkflowRelationsByUserId(string userId);
        Task<IEnumerable<int>> GetUserWorkflows(string userId);
        Task<bool> CheckUserWorkflow(string userId, int workflowId);
        Task ClearStatusCount();
        Task ClearEntries();
        Task<StatusCount> GetStatusCount();
        Task<IEnumerable<WorkflowEntry>> GetEntries();
        Task<HistoryWorkflowEntry> GetHistoryWorkflowEntry(int id);
        Task<IEnumerable<HistoryWorkflowEntry>> GetHistoryEntries();
        Task<IEnumerable<HistoryWorkflowEntry>> GetHistoryEntries(GetListParams<HistoryWorkflowEntry> par);
        Task<int> GetHistoryEntriesCount(GetListParams<HistoryWorkflowEntry> par);
        Task<int> GetEntriesCount(GetListParams<WorkflowEntry> par);
        Task<DateTime> GetHistoryEntryStatusDateMin();
        Task<DateTime> GetHistoryEntryStatusDateMax();
        Task<DateTime> GetEntryStatusDateMin();
        Task<DateTime> GetEntryStatusDateMax();
        Task IncrementDisabledCount();
        Task IncrementRunningCount();
        Task<WorkflowEntry> GetEntry(int workflowId);
        Task InsertEntry(WorkflowEntry entry);
        Task UpdateEntry(WorkflowEntry entry);
        Task IncrementDisapprovedCount();
        Task IncrementDoneCount();
        Task IncrementWarningCount();
        Task IncrementFailedCount();
        Task InsertHistoryEntry(HistoryWorkflowEntry entry);
        Task DecrementRunningCount();
        Task IncrementStoppedCount();
        Task IncrementPendingCount();
        Task DecrementPendingCount();
        Task<string> GetEntryLogs(int entryId);
        Task<string> GetHistoryEntryLogs(int entryId);
    }
}
