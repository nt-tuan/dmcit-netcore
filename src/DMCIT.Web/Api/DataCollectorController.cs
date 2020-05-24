using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.DataCollector;
using DMCIT.Core.Entities.Processes;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Services;
using DMCIT.Web.ApiModels.DataCollector;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMCIT.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DataCollectorController : ControllerBase
    {
        private readonly ISettingRepository _setting;
        private readonly ICoreRepository _core;
        private readonly IDataCollectorRepository _icollector;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProcessManagerService _processService;
        public DataCollectorController(ISettingRepository setting, ICoreRepository core, IDataCollectorRepository collector, IProcessManagerService processService, UserManager<AppUser> userManager)
        {
            _setting = setting;
            _core = core;
            _icollector = collector;
            _userManager = userManager;
            _processService = processService;
        }

        [HttpGet]
        [Route("server/{id}")]
        public async Task<List<DistributedServer>> GetServerDetail(string id)
        {
            var ss = await _icollector.GetDistributedServer(id);
            foreach (var s in ss)
            {
                foreach (var item in s.DistributedServerTableDefineds)
                {
                    item.DistributedServer = null;
                }
            }
            return ss;
        }

        [HttpGet]
        [Route("servers")]
        public async Task<ICollection<DistributedServer>> GetServers()
        {
            var s = await _icollector.GetDistributedServers();
            return s;
        }

        [HttpPost]
        [Route("server")]
        public async Task<bool> UpdateServer(DistributedServerModel model)
        {
            var e = model.ToEntity();
            await _icollector.UpdateDistributedServer(e, await _userManager.GetUserAsync(User));
            return true;
        }

        [HttpPost]
        [Route("DownloadDiary131")]
        public async Task<string> LoadLiability()
        {
            var user = await _userManager.GetUserAsync(User);
            var jobId = BackgroundJob.Enqueue<IDataCollectorRepository>(u => u.LoadDiary131sProcess(user, null));
            await _processService.RegisterProcess(jobId, LoadDiary131sProcess.ProcessName, user);
            return jobId;
        }
    }
}
