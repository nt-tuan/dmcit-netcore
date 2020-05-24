using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Providers.Excel;
using DMCIT.Web.ApiModels;
using DMCIT.Web.ApiModels.Messaging;
using DMCIT.Web.ApiModels.Messaging.Group;
using DMCIT.Web.ApiModels.Messaging.Recipient;
using DMCIT.Web.Configurations;
using DMCIT.Web.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Web.Api
{
    [Route("api/[controller]")]
    [ValidateModel]
    [ApiController]
    [Authorize]
    public class MessageReceiverController : ControllerBase
    {
        readonly IMessageReceiverRepository _iReceiver;
        readonly UserManager<AppUser> _userManager;
        readonly ICoreRepository _core;
        readonly ApiConfiguration _config;
        readonly ISaleRepository _sale;
        readonly ITemplateRepository _template;

        public MessageReceiverController(UserManager<AppUser> userManager, IMessageReceiverRepository ireceiver,
            ICoreRepository core, IOptions<ApiConfiguration> option, ISaleRepository sale, ITemplateRepository template)
        {
            _userManager = userManager;
            _iReceiver = ireceiver;
            _core = core;
            _config = option.Value;
            _sale = sale;
            _template = template;
        }

        [HttpGet]
        [Route("ReceiverCategories")]
        public async Task<ICollection<ReceiverCategory>> Get()
        {
            return await _iReceiver.GetCategories(DateTime.Now);
            //return await _iReceiver.GetCategories();
        }

        [HttpPost]
        [Route("receivers")]
        public async Task<IActionResult> GetReceivers(TableParameter<MessageReceiverFilterModel, MessageReceiver> param)
        {
            var eParam = param.ToEntityParam();
            var modelItems = (await _iReceiver.GetReceivers(eParam)).Select(u => new MessageReceiverModel(u));
            var count = await _iReceiver.GetReceiversCount(eParam);
            var model = new BaseListModel<MessageReceiverModel>(modelItems.ToList(), param.page, param.pageSize, count);
            return Ok(model.ToResponseModel());
        }

        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [HttpPost]
        [Route("PreviewReceivers")]
        public async Task<IActionResult> PreviewReceivers()
        {
            if (Request.Form.Files.Count < 1)
                return NotFound();

            var proDict = (await _iReceiver.GetProviders()).Select(u => new ProviderModel(u)).ToDictionary(u => u.code);
            if (Request.Form.Files.Count < 1)
            {
                return NotFound();
            }
            var file = Request.Form.Files[0];
            var stream = file.OpenReadStream();

            var parser = await _template.GetParserAsync<ExcelImporter<InvalidableModel<MessageReceiverModel>>, ReceiverExcelImportModel>();
            var importedData = (await parser.Parse(stream)).Select(u => u.Model.ToEntity());

            var reviewResult = await _iReceiver.ReviewReceiver(importedData);

            var rs = reviewResult.Select(u =>
            {
                var rItem = new InvalidableModel<MessageReceiverModel>(new MessageReceiverModel(u.Entity), u.Result.Result.Select(v => new MessageModel(v)).ToList());
                return rItem;
            });

            var exporter = await _template.GetParserAsync<ExcelExporter, ErrorableReceiverExcelExportableModel>();
            var rsStream = await exporter.Parse(rs);

            return File(rsStream.GetBuffer(), "application/octet-stream", "review.xlsx");
        }

        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [HttpPost]
        [Route("ImportReceivers")]
        public async Task<IActionResult> ImportReceivers()
        {
            if (Request.Form.Files.Count < 1)
                return NotFound();
            var currentUser = await _userManager.GetUserAsync(User);
            if (Request.Form.Files.Count < 1)
            {
                return NotFound();
            }
            var file = Request.Form.Files[0];
            var stream = file.OpenReadStream();

            var parser = await _template.GetParserAsync<ExcelImporter<InvalidableModel<MessageReceiverModel>>, ReceiverExcelImportModel>();
            var importedData = (await parser.Parse(stream)).Select(u => u.Model.ToEntity()).ToList();

            var reviewResult = await _iReceiver.ReviewReceiver(importedData);
            var rs = new List<InvalidableModel<MessageReceiverModel>>();
            foreach (var item in reviewResult)
            {
                var e = item.Entity;
                var messages = item.Result.Result.Select(u => new MessageModel(u)).ToList();
                var itemModel = new InvalidableModel<MessageReceiverModel>(new MessageReceiverModel(e), messages);
                try
                {
                    var rpe = await _iReceiver.UpdateOrAddReceiver(e, currentUser);
                    itemModel = new InvalidableModel<MessageReceiverModel>(new MessageReceiverModel(rpe));
                }
                catch (Exception ex)
                {
                    var inner = ex.InnerException;
                    var message = ex.Message;
                    while (inner != null)
                    {
                        message += Environment.NewLine + inner.Message;
                        inner = inner.InnerException;
                    }
                    itemModel.Message.Add(MessageModel.CreateError(message));
                }
                rs.Add(itemModel);
            }

            var exporter = await _template.GetParserAsync<ExcelExporter, ErrorableReceiverExcelExportableModel>();
            var rsStream = await exporter.Parse(rs);

            return File(rsStream.GetBuffer(), "application/octet-stream", "result.xlsx");
        }

        [HttpPost]
        [Route("ExportReceivers")]
        public async Task<IActionResult> ExportReceivers(TableParameter<MessageReceiverFilterModel, MessageReceiver> param)
        {
            var eParam = param.ToEntityParam();
            var modelItems = (await _iReceiver.GetReceivers(eParam)).Select(u => new MessageReceiverModel(u)).ToList();
            var proList = await _iReceiver.GetProviders();
            var proDict = proList.Select(u => new ProviderModel(u)).ToDictionary(u => u.code);

            var parser = await _template.GetParserAsync<ExcelExporter, RecipientExcelExportModel>();

            var stream = await parser.Parse(modelItems);

            return File(stream.GetBuffer(), "application/octet-stream", "result.xlsx");
        }


        [HttpPost]
        [Route("DeleteReceivers")]
        public async Task<IActionResult> DeleteReceivers(IntCollectionModel model)
        {
            foreach (var id in model.collection)
            {
                await _iReceiver.DeleteReceiver(id, await _userManager.GetUserAsync(User), DateTime.Now);
            }
            return Ok(new ResponseModel(true));
        }

        [HttpPost]
        [Route("receivers/{id}")]
        public async Task<IActionResult> GetReceiver(int id)
        {
            var entity = await _iReceiver.GetReceiverById(id, DateTime.Now);
            return Ok(new ResponseModel(new MessageReceiverModel(entity)));
        }

        [HttpPost]
        [Route("ReceiverProviders/{id}")]
        public async Task<IActionResult> GetReceiverProviders(int id)
        {
            var entities = await _iReceiver.GetReceiverProvider(id);
            var lst = entities.Select(u => new ReceiverProviderModel(u));
            return Ok(new ResponseModel(lst));
        }

        [HttpPost]
        [Route("AddCustomerReceiver")]
        public async Task<IActionResult> AddCustomerReceiver(IntCollectionModel p)
        {
            var messages = new List<string>();
            var rs = new List<MessageReceiverModel>();
            foreach (var id in p.collection)
            {
                var customer = await _sale.GetCustomerById(id, DateTime.Now);
                if (customer == null)
                {
                    messages.Add($"CUSTOMER #{id} NOT FOUND");
                    continue;
                }
                var receiver = await _iReceiver.AddCustomerReceiver(customer, await _userManager.GetUserAsync(User), DateTime.Now);
                var rsitem = new MessageReceiverModel(receiver);
                rs.Add(rsitem);
            }
            var response = new ResponseModel(messages: messages, re: rs);

            return Ok(response);
        }

        [HttpPost]
        [Route("AddEmployeeReceiver")]
        public async Task<IActionResult> AddEmployeeReceiver(IntCollectionModel p)
        {
            var messages = new List<string>();
            var rs = new List<MessageReceiverModel>();
            foreach (var id in p.collection)
            {
                try
                {
                    var employee = await _core.GetEmployeeById(id);
                    if (employee == null)
                    {
                        messages.Add($"EMPLOYEE #{id} NOT FOUND");
                        continue;
                    }
                    var receiver = await _iReceiver.AddEmployeeReceiver(employee, await _userManager.GetUserAsync(User), DateTime.Now);
                    var rsitem = new MessageReceiverModel(receiver);
                    rs.Add(rsitem);
                }
                catch (Exception e)
                {
                    messages.Add(e.Message);
                }
            }

            var rsmodel = new ResponseModel(messages: messages, re: rs);
            return Ok(rsmodel);
        }

        [HttpPost]
        [Route("AddReceiverProvider")]
        public async Task<IActionResult> AddReceiverProvider(UpdateReceiverProviderModel model)
        {
            var receiver = await _iReceiver.GetReceiverById(model.receiverId, DateTime.Now);
            if (receiver == null)
                return NotFound();
            var entity = new ReceiverProvider
            {
                MessageReceiverId = receiver.OriginId ?? receiver.Id,
                ReceiverAddress = model.receiverAddress,
                MessageServiceProviderId = model.provider.id
            };
            var result = await _iReceiver.AddReceiverProvider(entity, await _userManager.GetUserAsync(User), DateTime.Now);
            var resultModel = new ReceiverProviderModel(result);
            return Ok(new ResponseModel(resultModel));
        }

        [HttpPost]
        [Route("DeleteReceiverProvider/{id}")]
        public async Task<IActionResult> DeleteReceiverProvider(int id)
        {
            await _iReceiver.DeleteReceiverProvider(id, await _userManager.GetUserAsync(User), DateTime.Now);
            return Ok(new ResponseModel(true));
        }

        [HttpPost]
        [Route("DeleteReceiver/{id}")]
        public async Task<IActionResult> DeleteReceiver(int id)
        {
            await _iReceiver.DeleteReceiver(id, await _userManager.GetUserAsync(User), DateTime.Now);
            return Ok();
        }

        [HttpPost]
        [Route("Providers")]
        public async Task<IActionResult> GetProviders()
        {
            var entities = await _iReceiver.GetProviders();
            var model = entities.Select(u => new ProviderModel(u));
            return Ok(new ResponseModel(model));
        }

        [HttpPost]
        [Route("GetGroup/{id}")]
        public async Task<IActionResult> Group(int id)
        {
            var group = await _iReceiver.GetGroupById(id, DateTime.Now);
            if (group == null)
                return NotFound();
            group.MessageReceiverGroupMessageReceivers = await _iReceiver.GetGroupMembers(id, DateTime.Now);
            var response = new GroupModel(group);
            return Ok(new ResponseModel(response));
        }

        [HttpPost]
        [Route("Groups")]
        public async Task<IActionResult> Groups(TableParameter param)
        {
            var groups = await _iReceiver.GetGroups(param.ToEntityParam<MessageReceiverGroup>());
            var lst = groups.Select(u => new GroupModel(u)).ToList();
            var total = await _iReceiver.GetGroupsCount(param.ToEntityParam<MessageReceiverGroup>());
            foreach (var item in lst)
            {
                item.count = await _iReceiver.GetGroupMemberCount(item.id, DateTime.Now);
            }
            var response = new BaseListModel<GroupModel>(lst.ToList(), param.page, param.pageSize, total);
            return Ok(response);
        }

        [HttpPost]
        [Route("AddGroup")]
        public async Task<IActionResult> AddGroup(AddGroupModel model)
        {
            var group = await _iReceiver.AddGroup(model.ToEntity(), await _userManager.GetUserAsync(User), DateTime.Now);
            return Ok(new ResponseModel(new GroupModel(group)));
        }

        [HttpPost]
        [Route("EditGroup/{id}")]
        public async Task<IActionResult> EditGroup(int id, AddGroupModel model)
        {
            model.id = id;
            var entity = model.ToEntity();
            await _iReceiver.UpdateGroup(entity, await _userManager.GetUserAsync(User), DateTime.Now);
            return Ok(new ResponseModel(true));
        }





    }
}
