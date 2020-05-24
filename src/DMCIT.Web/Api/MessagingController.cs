using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Entities.Messaging.Settings;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Services;
using DMCIT.Web.ApiModels;
using DMCIT.Web.ApiModels.Messaging;
using DMCIT.Web.Configurations;
using DMCIT.Web.Filters;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DMCIT.Web.Api
{
    [Route("api/[controller]")]
    [ValidateModel]
    [ApiController]
    [Authorize]
    public class MessagingController : ControllerBase
    {
        readonly IMessageReceiverRepository _iReceiver;
        readonly IMessagingRepository _iMessaging;
        readonly UserManager<AppUser> _userManager;
        readonly ISettingRepository _isetting;
        readonly ApiConfiguration _config;
        readonly IProcessManagerService _process;
        public MessagingController(IMessageReceiverRepository receiver, UserManager<AppUser> userManager, IOptions<ApiConfiguration> config, ISettingRepository setting, IMessagingRepository imessaging, IProcessManagerService process)
        {
            _iReceiver = receiver;
            _userManager = userManager;
            _config = config.Value;
            _isetting = setting;
            _iMessaging = imessaging;
            _process = process;
        }

        // GET: api/<controller>
        #region MESSAGE BATCH
        [HttpPost]
        [Route("MessageBatches")]
        public async Task<IActionResult> GetMessageBatches(TableParameter<MessageBatchFilterModel, MessageBatch> model)
        {
            var eParam = model.ToEntityParam();
            var entities = await _iMessaging.GetMessageBatches(eParam);
            var data = new List<MessageBatchModel>();
            foreach (var u in entities)
            {
                var item = new MessageBatchModel(u);
                var sentMessageParam = new GetListParams<SentMessage>
                {
                    extension = query => query.Where(v => v.MessageBatchId == u.Id)
                };
                item.count = await _iMessaging.GetMessagesCount(sentMessageParam);
                data.Add(item);
            };
            var count = await _iMessaging.GetMessageBatchesCount(eParam);
            var response = new BaseListModel<MessageBatchModel>(data, model.page, model.pageSize, count);
            return Ok(response);
        }

        [HttpPost]
        [Route("GetMessageBatch/{id}")]
        public async Task<IActionResult> GetMessageBatch(int id)
        {
            var batch = await _iMessaging.GetMessageBatch(id);
            return Ok(new ResponseModel(new MessageBatchModel(batch)));
        }

        [HttpPost]
        [Route("GetSentMessages")]
        public async Task<IActionResult> GetSentMessages(TableParameter<SentMessageFilterModel, SentMessage> param)
        {
            //var sentMessage = _imessage.GetMessage
            var eParam = param.ToEntityParam();
            var entities = await _iMessaging.GetSentMessages(eParam);


            var count = await _iMessaging.GetMessagesCount(eParam);
            return Ok(new BaseListModel<SentMessageModel>(entities.Select(u => new SentMessageModel(u)).ToList(), param.page, param.pageSize, count));
        }

        [HttpPost]
        [Route("GetSentMessage/{id}")]
        public async Task<IActionResult> GetSentMessage(int id)
        {
            //var entity = _imessage.GetMessage
            var entity = await _iMessaging.GetSentMessageById(id);
            if (entity == null)
                return NotFound();
            return Ok(new ResponseModel(new SentMessageModel(entity)));
        }
        #endregion
        [HttpPost]
        [Route("SendCustomMessage")]
        public async Task<IActionResult> BroadcastMessage(BroadcastMessageModel model)
        {
            var entities = await _iReceiver.GetReceiverProviders(model.receivers, model.groups, model.providers);

            //create message batch
            var messageList = new List<SentMessage>();
            foreach (var item in entities)
            {
                messageList.Add(new SentMessage
                {
                    Content = model.content,
                    ReceiverProviderId = item.Id
                });
            }
            var batch = await _iMessaging.CreateMessageBatch(messageList, await _userManager.GetUserAsync(User));
            var user = await _userManager.GetUserAsync(User);
            if (batch != null)
            {
                var jobId = BackgroundJob.Enqueue<IMessagingRepository>(u =>
                u.SendMessageBatchHangfire(batch.Id, user, null));
                await _process.RegisterProcess(jobId, $"Send message batch #{batch.Id}", user);
                return Ok(jobId);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("ReviewReceivers")]
        public async Task<IActionResult> ReviewReceivers(ReviewReceiversModel model)
        {
            var entities = await _iReceiver.GetReceiverProviders(model.receivers, model.groups, model.providers);
            var rp = entities.Select(u => new DetailReceiverProviderModel(u));
            return Ok(new ResponseModel(rp));
        }

        #region Viettel SMS
        [HttpGet]
        [Route("viettelsmssetting")]
        public async Task<ViettelSMSSetting> GetViettelSMSSetting()
        {
            return await Task.Run(() =>
            {
                var store = _isetting.GetSettingStore();
                var setting = store.GetSetting<ViettelSMSSetting>();
                return setting;
            });
        }

        [HttpPost]
        [Route("viettelsmssetting")]
        public async Task<IActionResult> UpdateViettelSMSSetting(ViettelSMSSetting model)
        {
            var settings = model.ToSettingEntities();
            await _isetting.UpdateSettings(settings, DateTime.Now, await _userManager.GetUserAsync(User));
            return Ok();
        }

        [HttpGet]
        [Route("defaultviettelsmssetting")]
        public async Task<ViettelSMSSetting> GetViettelSMSDefaultSetting()
        {
            return await Task.Run(() =>
            {
                var setting = new ViettelSMSSetting();
                setting.LoadDefault();
                return setting;
            });
        }

        #endregion
        #region SMTP
        [HttpGet]
        [Route("SMTPsetting")]
        public async Task<SMTPSetting> GetSTMPSetting()
        {
            return await Task.Run(() =>
            {
                var store = _isetting.GetSettingStore();
                var setting = store.GetSetting<SMTPSetting>();
                return setting;
            });
        }

        [HttpGet]
        [Route("DefaultSMTPSetting")]
        public async Task<SMTPSetting> GetDefaultSMTPSetting()
        {
            return await Task.Run(() =>
            {
                var setting = new SMTPSetting();
                setting.LoadDefault();
                return setting;
            });
        }

        [HttpPost]
        [Route("SMTPsetting")]
        public async Task<IActionResult> UpdateSMTPSetting(SMTPSetting model)
        {
            var settings = model.ToSettingEntities();
            await _isetting.UpdateSettings(settings, DateTime.Now, await _userManager.GetUserAsync(User));
            return Ok();
        }
        #endregion
    }
}
