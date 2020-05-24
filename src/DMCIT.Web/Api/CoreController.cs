using DMCIT.Core.Entities;
using DMCIT.Core.Entities.Core;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Data.Exceptions.Accounting;
using DMCIT.Infrastructure.Services;
using DMCIT.Web.ApiModels.Core;
using DMCIT.Web.ApiModels.System;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace DMCIT.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoreController : ControllerBase
    {
        private readonly ISettingRepository _setting;
        private readonly ICoreRepository _core;
        private readonly UserManager<AppUser> _userManager;
        private readonly IJobTrackingRepository _job;
        private readonly IProcessManagerService _processService;
        public CoreController(ISettingRepository setting, ICoreRepository core, UserManager<AppUser> userManager, IJobTrackingRepository job, IProcessManagerService processService)
        {
            _setting = setting;
            _core = core;
            _userManager = userManager;
            _job = job;
            _processService = processService;
        }

        [HttpGet]
        [Route("setting")]
        public async Task<GeneralSettingModel> GetGeneralSetting()
        {
            return await Task.Run(() =>
            {
                var store = _setting.GetSettingStore();
                var setting = store.GetSetting<GeneralSetting>();
                return new GeneralSettingModel(setting);
            });
        }

        [HttpPost]
        [Route("setting")]
        public async Task<IActionResult> UpdateGeneralSetting(GeneralSettingModel model)
        {
            var settings = model.ToEntity().ToSettingEntities();
            await _setting.UpdateSettings(settings, DateTime.Now, await _userManager.GetUserAsync(User));
            return Ok(new { data = true });
        }


        #region ACCOUNTING PERIOD
        [HttpGet]
        [Route("accountingperiods")]
        public async Task<ICollection<AccountingPeriodModel>> GetAccountingPeriods()
        {
            var e = await _core.GetAccountingPeriods();
            return e.Select(u => new AccountingPeriodModel(u)).ToList();
        }

        [HttpGet]
        [Route("accountingperiod/{id}")]
        public async Task<AccountingPeriodModel> GetAccountingPeriod(int id)
        {
            var e = await _core.GetAccountingPeriodById(id);
            return new AccountingPeriodModel(e);
        }

        [HttpPut]
        [Route("accountingperiod")]
        public async Task<AccountingPeriodModel> AddAccountingPeriod(AccountingPeriodModel model)
        {
            var e = model.ToEntity();
            await _core.AddAccountingPeriod(e, await _userManager.GetUserAsync(User));
            return new AccountingPeriodModel(e);
        }

        [HttpPost]
        [Route("accountingperiod")]
        public async Task<bool> UpdateAccountingPeriod(AccountingPeriodModel model)
        {
            await _core.UpdateAccountingPeriod(model.ToEntity(), await _userManager.GetUserAsync(User));
            return true;
        }

        [HttpGet]
        [Route("LastAccountingPeriod")]
        public async Task<AccountingPeriodModel> GetLastAccountingPeriod()
        {
            var e = await _core.GetLastAccountingPeriod();
            if (e == null)
                return null;
            return new AccountingPeriodModel(e);
        }

        [HttpGet]
        [Route("OpeningAccountingPeriod")]
        public async Task<AccountingPeriodModel> GetOpeningAccountingPeriod()
        {
            var e = await _core.GetOpeningAccountPeriod();
            return new AccountingPeriodModel(e);
        }

        [HttpPost]
        [Route("OpenAccountingPeriod")]
        public async Task<bool> OpenAccountingPeriod()
        {
            await _core.OpenAccountingPeriod(await _userManager.GetUserAsync(User));
            return true;
        }

        [HttpPost]
        [Route("CloseAccountingPeriod")]
        public async Task<string> CloseAccountingPeriod()
        {
            var actor = await _userManager.GetUserAsync(User);
            var current = await _core.GetOpeningAccountPeriod();
            if (current == null)
            {
                throw new OpeningAccountingPeriodNotFound().ToException();
            }
            string jobId = BackgroundJob.Enqueue<ICoreRepository>(u => u.CloseAccountingPeriod(actor, null));
            await _processService.RegisterProcess(jobId, "CLOSE ACCOUNTING PERIOD", actor);
            return jobId;
        }

        [HttpPost]
        [Route("RevertAccountingPeriod")]
        public async Task<bool> RevertAccountingPeriod()
        {
            await _core.RevertAccountingPeriod(await _userManager.GetUserAsync(User));
            return true;
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAccountingPeriod(int id)
        {
            var ap = await _core.GetAccountingPeriodById(id);
            var user = await _userManager.GetUserAsync(User);
            if (ap == null)
                return false;
            await _core.DeleteAccountingPeriod(ap, user);
            return true;
        }
        #endregion

    }
}
