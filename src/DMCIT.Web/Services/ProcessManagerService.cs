using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Processes;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Services;
using DMCIT.Web.ApiModels.Progress;
using DMCIT.Web.Hubs;
using Hangfire.Server;
using Helper;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DMCIT.Web.Services
{
    public class ProgressManagerService : IProcessManagerService
    {
        #region STATIC DEFINED
        public static string PROGRESS_MANAGER_GROUP = "PROGRESS_MANAGER";
        public static string PROCESS_BEGIN_METHOD = "OnProcessBegin";
        public static string PROGRESS_BEGIN_METHOD = "OnProgressBegin";
        public static string PROGRESS_CHANGE_STATE_METHOD = "OnProgressChangeState";
        public static string PROGRESS_INSCREASE_METHOD = "onProgressInscrease";
        //public static string PROGRESS_ERROR_METHOD = "OnProgressFailed";
        public static string PROCESS_MESSAGE_METHOD = "OnProcessMessage";
        public static string PROGRESS_END_METHOD = "OnProgressEnd";
        public static string PROCESS_UNREGISTER_METHOD = "OnProcessUnregister";
        public static string PROGRESS_TRACKER_GROUP_PREFIX = "PROGRESS_TRACKER_";
        public static string GetTrackerGroup(string id)
        {
            return PROGRESS_TRACKER_GROUP_PREFIX + id;
        }
        #endregion
        #region PRIVATE PROPERTIES
        private ConcurrentDictionary<string, BackgroundProcess> CurrentProcesses { get; set; } = new ConcurrentDictionary<string, BackgroundProcess>();
        private IHubContext<ProcessHub> _hub;
        private IJobTrackingRepository _job { get; set; }
        #endregion
        public ProgressManagerService(IHubContext<ProcessHub> hub, IJobTrackingRepository job)
        {
            _hub = hub;
            _job = job;
        }

        #region PRIVATE METHODS
        async Task sendProcessBeginMessage(BackgroundProcess process)
        {
            if (process != null)
                await _hub.Clients.Groups(PROGRESS_MANAGER_GROUP, GetTrackerGroup(process.JobId)).SendAsync(PROCESS_BEGIN_METHOD, process.JobId, process.Name);
        }

        async Task sendProgressBeginMessage(BaseProgress progress)
        {
            if (progress != null && progress.Process != null)
                await _hub.Clients.Groups(GetTrackerGroup(progress.Process.JobId)).SendAsync(PROGRESS_BEGIN_METHOD, new ProgressModel(progress));
        }

        async Task sendProgressEndMessage(BaseProgress progress)
        {
            if (progress != null && progress.Process != null)
                await _hub.Clients.Groups(PROGRESS_MANAGER_GROUP, GetTrackerGroup(progress.Process.JobId)).SendAsync(PROGRESS_END_METHOD, new ProgressModel(progress));
        }

        async Task sendProgressStateMessage(BaseProgress progress)
        {
            if (progress != null && progress.Process != null)
                await _hub.Clients.Groups(GetTrackerGroup(progress.Process.JobId)).SendAsync(PROGRESS_CHANGE_STATE_METHOD, new ProgressModel(progress));
        }

        async Task sendProgressInscrease(BaseProgress progress)
        {
            if (progress != null && progress.Process != null)
                await _hub.Clients.Groups(GetTrackerGroup(progress.Process.JobId)).SendAsync(PROGRESS_INSCREASE_METHOD, progress.Percent);
        }

        async Task sendProcessMessage(BackgroundProcess process, ProgressMessage message)
        {
            if (process != null)
            {
                process.Messages.Add(message);
                await _hub.Clients.Groups(GetTrackerGroup(process.JobId)).SendAsync(PROCESS_MESSAGE_METHOD, message);
            }
        }

        async Task sendProcessSuccessMessage(BackgroundProcess process, string message)
        {
            if (process != null)
            {
                var mes = new ProgressMessage
                {
                    Type = ProgressMessage.ProgressType.SUCCESS,
                    Message = message
                };
                await sendProcessMessage(process, mes);
            }
        }

        async Task sendProcessFailedMessage(BackgroundProcess process, string message)
        {
            if (process != null)
            {
                var mes = new ProgressMessage
                {
                    Type = ProgressMessage.ProgressType.ERROR,
                    Message = message
                };
                await sendProcessMessage(process, mes);
            }
        }


        async Task sendProcessUnregisterMessage(BackgroundProcess process)
        {
            if (process != null)
                await _hub.Clients.Groups(PROGRESS_MANAGER_GROUP, GetTrackerGroup(process.JobId)).SendAsync(PROCESS_UNREGISTER_METHOD);
        }

        #endregion

        #region INTERFACE IMPLEMENTED
        public async Task<BaseProgress> BeginProgress(string jobId, BaseProgress progress)
        {
            BackgroundProcess existance = GetProgress(jobId);
            if (existance != null)
            {
                lock (existance)
                {
                    existance.BeginProgress(progress);
                }
                await sendProgressBeginMessage(progress);
                return progress;
            }
            else
            {
                throw new Exception($"PROCESS ${jobId} NOT FOUND");
            }
        }

        public async Task<BaseProgress> UpdateProgress(BaseProgress progress)
        {
            BackgroundProcess process = GetProgress(progress.Process.JobId);

            if (process != null)
            {
                process.UpdateProgressState(progress);
                BaseProgress rP = process.RunningProgress;
                await sendProgressStateMessage(rP);
                return rP;
            }
            else
            {
                throw new Exception("NO RUNNING PROGRESS");
            }

        }

        public async Task EndProgress(string jobId)
        {
            BackgroundProcess process = GetProgress(jobId);
            if (process != null)
            {
                var running = process.RunningProgress;
                process.EndProgress();
                await sendProgressEndMessage(running);
            }
        }

        public BackgroundProcess GetProgress(string jobId)
        {
            BackgroundProcess progress;
            CurrentProcesses.TryGetValue(jobId, out progress);
            return progress;
        }

        public IEnumerable<BackgroundProcess> GetAllProgress()
        {
            return CurrentProcesses.Values;
        }

        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);
        public async Task RegisterProcess(string jobId, string title, AppUser actor)
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                try
                {
                    var process = GetProcess(jobId);
                    return;
                }
                catch { }
                var newProcess = new BackgroundProcess();
                newProcess.JobId = jobId;
                newProcess.Name = title;

                var rs = await _job.AddRunningJob(newProcess, actor);
                lock (this)
                {
                    if (rs != null)
                        CurrentProcesses.TryAdd(rs.JobId, rs);
                }
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

        public async Task<BackgroundProcess> UnregisterProcess(string jobId, string status, string reason, AppUser actor)
        {

            BackgroundProcess process;
            CurrentProcesses.TryRemove(jobId, out process);
            if (process != null)
            {
                var rs = await _job.StopRunningJob<BackgroundProcess>(process.Id, status, reason, actor);
                await sendProcessUnregisterMessage(process);
            }
            return process;
        }


        public async Task EndProgressWithError(string jobId, string message)
        {
            BackgroundProcess process = GetProgress(jobId);
            if (process != null)
            {
                var running = process.RunningProgress;
                process.EndProgress();
                await sendProcessFailedMessage(process, message);
                await sendProgressEndMessage(running);
            }
        }

        //public async Task<T> StartProcess<T>(PerformContext context, string title, Task<T> action, AppUser actor)
        //{
        //    var jobId = context.BackgroundJob.Id;
        //    var process = GetProgress(jobId);
        //    var root = false;
        //    if (process == null)
        //    {
        //        root = true;
        //        await RegisterProcess(context.BackgroundJob.Id, title, actor);
        //    }

        //    var rs = await action;

        //    if (root)
        //    {
        //        await UnregisterProcess(jobId, actor);
        //    }
        //    return rs;
        //}

        public async Task StartProcess(string jobId, AppUser actor)
        {
            var process = GetProcess(jobId);
            var bgProcess = _job.StartJob(jobId, actor).Result;
            lock (process)
            {
                process.Copy(bgProcess);
            }
            await sendProcessBeginMessage(process);
        }

        public async Task StartProcess(PerformContext context, string title, Func<Task> action, AppUser actor)
        {
            var jobId = context.BackgroundJob.Id;
            var process = GetProgress(jobId);
            var rootStart = false;
            Exception throwException = null;
            if (process == null)
            {
                await RegisterProcess(jobId, title, actor);
            }

            try
            {
                await StartProcess(jobId, actor);
                rootStart = true;
            }
            catch (Exception e)
            {
                var me = e.Message;
            }
            try
            {
                await action();
            }
            catch (Exception e)
            {
                var message = e.Message + Environment.NewLine + e.StackTrace;
                var inner = e.InnerException;
                while (inner != null)
                {
                    message += Environment.NewLine + inner.Message + inner.StackTrace;
                    inner = inner.InnerException;
                }


                await AddErrorMessage(jobId, message);
                await EndProgress(jobId);
                throwException = e;
            }

            if (rootStart)
            {
                var message = "";
                if (throwException != null)
                    message = UtilityHelper.GetExceptionMessage(throwException);
                await UnregisterProcess(jobId, BackgroundProcess.END_PROCESS, message, actor);
            }
            else if (throwException != null)
            {
                throw throwException;
            }
        }

        public async Task UpdateProgress(string jobId, string description)
        {
            var progress = GetCurrentProgress(jobId);
            progress.SetDescription(description);
            await sendProgressStateMessage(progress);
        }

        public async Task InitCounting(string jobId, int max)
        {
            var progress = GetCurrentProgress(jobId);
            progress.InitCount(max);
            await sendProgressInscrease(progress);
        }

        public async Task Increase(string jobId, int n)
        {
            var progress = GetCurrentProgress(jobId);
            progress.Inscrease(n);
            await sendProgressInscrease(progress);
        }

        public async Task AddErrorMessage(string jobId, string message)
        {
            var process = GetProcess(jobId);
            await sendProcessFailedMessage(process, message);
        }

        public BackgroundProcess GetProcess(string jobId)
        {
            BackgroundProcess process;
            CurrentProcesses.TryGetValue(jobId, out process);
            if (process == null)
                throw new Exception($"Process #{jobId} not found");
            return process;
        }

        public BaseProgress GetCurrentProgress(string jobId)
        {
            var process = GetProcess(jobId);
            if (process.RunningProgress == null)
            {
                throw new Exception("Running progress not found");
            }
            return process.RunningProgress;
        }

        public async Task AddSuccessMessage(string jobId, string message)
        {
            var process = GetProcess(jobId);
            await sendProcessSuccessMessage(process, message);
        }

        #endregion
    }
}
