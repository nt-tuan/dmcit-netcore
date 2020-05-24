using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Sales;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Providers.Excel;
using DMCIT.Web.ApiModels;
using DMCIT.Web.ApiModels.Sales;
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
    [ApiController]
    [ValidateModel]
    [Authorize]
    public class SalesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ISaleRepository _sale;
        private readonly ISettingRepository _setting;
        private readonly ITemplateRepository _template;
        readonly ApiConfiguration _config;
        public SalesController(UserManager<AppUser> userManager, ISaleRepository sale, ISettingRepository setting, ITemplateRepository template, IOptions<ApiConfiguration> config)
        {
            _userManager = userManager;
            _sale = sale;
            _config = config.Value;
            _setting = setting;
            _template = template;
        }

        [HttpPost]
        [Route("customers")]
        public async Task<IActionResult> GetCustomers(TableParameter<CustomerFilterModel, Customer> model)
        {
            var eParams = model.ToEntityParam();
            var data = (await _sale.GetCustomers(eParams));
            foreach (var item in data)
            {
                if (item.DistributorId != null)
                    item.Distributor = await _sale.GetDistributorById(item.DistributorId ?? 0);
            }
            var lst = data.Select(u => new CustomerModel(u)).ToList();
            var response = new BaseListModel<CustomerModel>(lst, model.page, model.pageSize, await _sale.GetCustomersCount(eParams));
            return Ok(response.ToResponseModel());
        }

        [HttpPost]
        [Route("customers/{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            var model = new CustomerModel(await _sale.GetCustomerById(id));
            return Ok(new ResponseModel(model));
        }

        [HttpPost]
        [Route("customers/update")]
        public async Task<IActionResult> UpdateCustomer(CustomerModel customer)
        {
            var entity = customer.ToEntity();
            await _sale.EditCustomer(entity, await _userManager.GetUserAsync(User));
            return Ok();
        }

        [HttpPost]
        [Route("customers/delete")]
        public async Task<IActionResult> DeleteCustomer(CustomerModel model)
        {
            var entity = model.ToEntity();
            await _sale.DeleteCustomer(entity, await _userManager.GetUserAsync(User));
            return Ok();
        }

        [HttpPost]
        [Route("distributors")]
        public async Task<IActionResult> GetDistributors()
        {
            var lst = (await _sale.GetDistributors()).Select(u => new DistributorModel(u)).ToList();
            return Ok(new ResponseModel(lst));
        }

        [HttpPost]
        [Route("distributors/{id}")]
        public async Task<IActionResult> GetDistributor(int id)
        {
            var entity = await _sale.GetDistributorById(id);
            return Ok(new ResponseModel(new DistributorModel(entity)));
        }

        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [HttpPost]
        [Route("PreviewCustomers")]
        public async Task<IActionResult> PreviewCustomer()
        {
            if (Request.Form.Files.Count < 1)
                return NotFound();

            //read max excel readable from system configuration.
            if (Request.Form.Files.Count < 1)
                return NotFound();

            var file = Request.Form.Files[0];
            var stream = file.OpenReadStream();

            var parser = await _template.GetParserAsync<ExcelImporter<CustomerModel>, CustomerExcelImportModel>();
            var importData = (await parser.Parse(stream)).Select(u => (u).ToEntity()).ToList();
            var mes = (await _sale.ReviewImportCustomer(importData)).ToList();
            var rs = new List<InvalidableModel<CustomerModel>>();
            foreach (var item in mes)
            {
                var model = new InvalidableModel<CustomerModel>(new CustomerModel(item));
                if (item.Id != default)
                {
                    model.Message.Add(MessageModel.CreateWarning("Existed"));
                }
                rs.Add(model);
            }

            var exportParser = await _template.GetParserAsync<ExcelExporter, CustomerExcelExportModel>();
            var rsStream = await exportParser.Parse(rs);

            return File(rsStream.GetBuffer(), "application/octet-stream", "review.xlsx");
        }

        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)]
        [HttpPost]
        [Route("ImportCustomers")]
        public async Task<IActionResult> ImportCustomer()
        {
            if (Request.Form.Files.Count < 1)
                return NotFound();
            var user = await _userManager.GetUserAsync(User);
            var file = Request.Form.Files[0];
            var stream = file.OpenReadStream();

            //import result
            var parser = await _template.GetParserAsync<ExcelImporter<CustomerModel>, CustomerExcelImportModel>();
            var importEntities = (await parser.Parse(stream))
                .Select(u => u.ToEntity());

            var entities = await _sale.ReviewImportCustomer(importEntities);

            var rs = new List<InvalidableModel<CustomerModel>>();

            foreach (var item in entities)
            {
                InvalidableModel<CustomerModel> rsModel = new InvalidableModel<CustomerModel>(new CustomerModel(item));
                try
                {
                    if (item.Id != default)
                    {
                        await _sale.EditCustomer(item, user);
                        rsModel = new InvalidableModel<CustomerModel>(new CustomerModel(item));
                        rsModel.Message.Add(MessageModel.CreateWarning("Updated"));
                    }
                    else
                    {
                        await _sale.AddCustomer(item, user);
                        rsModel = new InvalidableModel<CustomerModel>(new CustomerModel(item));
                    }
                }
                catch (Exception e)
                {
                    var message = e.Message;
                    var inner = e.InnerException;
                    var tab = "-";
                    var count = 5;
                    while (inner != null && count > 0)
                    {
                        message += Environment.NewLine + tab + inner.Message;
                        tab += "-";
                        inner = inner.InnerException;
                        count--;
                    }
                    message += Environment.NewLine + e.StackTrace;

                    rsModel.Message.Add(MessageModel.CreateError(message));
                }
                rs.Add(rsModel);
            }

            //Export result
            var exportParser = await _template.GetParserAsync<ExcelExporter, CustomerExcelExportModel>();
            var rsStream = await exportParser.Parse(rs);
            return File(rsStream.GetBuffer(), "application/octet-stream", "review.xlsx");
        }
    }
}
