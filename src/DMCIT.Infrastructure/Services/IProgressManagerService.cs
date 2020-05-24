using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Processes;
using DMCIT.Core.SharedKernel;
using Hangfire.Server;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Services
{
    public interface IProcessManagerService
    {
        Task RegisterProcess(string jobId, string title, AppUser actor);
        Task StartProcess(string jobId, AppUser actor);
        //Task<T> RegisterProcess<T>(PerformContext context, string title, Task<T> taskCall, AppUser actor);
        Task StartProcess(PerformContext context, string title, Func<Task> taskCall, AppUser actor);

        Task<BackgroundProcess> UnregisterProcess(string jobId, string status, string reason, AppUser actor);
        Task<BaseProgress> BeginProgress(string jobId, BaseProgress progress);
        Task UpdateProgress(string jobId, string description);
        Task InitCounting(string jobId, int n);
        Task Increase(string jobId, int n);
        Task AddErrorMessage(string jobId, string message);
        Task AddSuccessMessage(string jobId, string message);
        Task EndProgress(string jobId);
        Task EndProgressWithError(string jobId, string message);
        BackgroundProcess GetProcess(string jobId);
        BaseProgress GetCurrentProgress(string jobId);
        IEnumerable<BackgroundProcess> GetAllProgress();
    }
}
