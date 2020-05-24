using DMCIT.Core.Entities.Core;
using DMCIT.Core.Interfaces;
using DMCIT.Web.ApiModels.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TemplateController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITemplateRepository _template;
        private readonly IServiceProvider _service;
        public TemplateController(ITemplateRepository template, IServiceProvider service, UserManager<AppUser> userManager)
        {
            _template = template;
            _service = service;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IEnumerable<TemplateModel>> GetTemplates()
        {
            var entities = await _template.GetTemplates();
            var rs = entities.Select(u => new TemplateModel(u));
            return rs;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult> GetTemplate(int id)
        {
            var tpl = await _template.GetTemplate(id);
            return Ok(new TemplateModel(tpl));
        }

        [Route("testreview")]
        [HttpGet]
        public async Task<string> ReviewTemplate(int id, string model)
        {
            return await _template.ReviewTemplate(id, model);
        }

        [HttpGet]
        [Route("testdownload")]
        public async Task<IActionResult> DownloadTemplate(int id, string model)
        {
            var stream = await _template.DownloadReviewTemplate(id, model);
            return File(stream.GetBuffer(), "application/octet-stream", "review.xlsx");
        }

        [Route("{id}")]
        [HttpPut]
        public async Task<bool> UpdateTemplate(int id, TemplateModel model)
        {
            var entity = model.ToEntity();
            entity.Id = id;
            await _template.UpdateTemplate(entity, await _userManager.GetUserAsync(User));
            return true;
        }
    }
}
