using DMCIT.Core.Entities.Core;
using DMCIT.Infrastructure.Services;
using DMCIT.Web.ApiModels.Progress;
using DMCIT.Web.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Web.Hubs
{
    public class ProcessHub : Hub
    {
        private readonly IProcessManagerService _service;
        private readonly UserManager<AppUser> _userManager;
        public ProcessHub(IProcessManagerService service, UserManager<AppUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        /// <summary>
        /// Start a progress base on its Id. If the progress is running, return that progress.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>


        public async Task<ProcessModel> RegisterProgress(string id)
        {
            var process = _service.GetProcess(id);
            var user = await _userManager.GetUserAsync(Context.User);

            if (user == null || (!await _userManager.IsInRoleAsync(user, "admin") && process.CreatedById != user.Id))
                return null;

            await Groups.AddToGroupAsync(Context.ConnectionId, ProgressManagerService.GetTrackerGroup(id));
            return new ProcessModel(process);
        }

        public async Task<IEnumerable<ProcessModel>> GetAllCollectingProcess()
        {
            var proceses = _service.GetAllProgress();
            await Groups.AddToGroupAsync(Context.ConnectionId, ProgressManagerService.PROGRESS_MANAGER_GROUP);
            return proceses.Select(u => new ProcessModel(u));
        }

        //[HubMethodName("SendMessage")]
        //public async Task<ProcessState> SendMessageJob(int batch)
        //{
        //    var process = new SendMessageProcess(batch);
        //    var curProcess = BaseProcessManager.GetCurrentProcesses(process.GetId());

        //    //There is no process execute sending this message batch
        //    string key = null;
        //    ProcessState state = null;
        //    if (curProcess == null)
        //    {
        //        key = process.GetId();
        //        state = process.GetState();
        //        BaseProcessManager.TryAddProcess(process);
        //        BackgroundJob.Enqueue<MessageSender>(u => u.RegisterSendingMessageProcess(batch));
        //    }
        //    else
        //    {
        //        key = curProcess.GetId();
        //        state = curProcess.GetState();
        //    }

        //    await Groups.AddToGroupAsync(Context.ConnectionId, key);

        //    return state;
        //}

        //[HubMethodName("AssociateMessagingJob")]
        //public async Task<ProcessState> AssociateMessagingJob(string key)
        //{
        //    //var key = SendingMessageJob.GetId(batchId);

        //    var p = BaseProcessManager.GetCurrentProcesses(key);
        //    if (p == null)
        //        return null;

        //    await Groups.AddToGroupAsync(Context.ConnectionId, key);

        //    var batchState = p.GetState();
        //    if (batchState != null)
        //    {    
        //        return batchState;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}
