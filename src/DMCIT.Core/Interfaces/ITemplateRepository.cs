using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public interface ITemplateRepository
    {
        //Task<T> GetParserAsync<T>(Type type) where T : IParser;
        Task<T> GetParserAsync<T, V>()
            where T : IParser
            where V : ITemplate;
        Task<Template> GetTemplate(int id);
        Task<IEnumerable<Template>> GetTemplates();
        Task<Template> AddTemplate(Template template, AppUser actor);
        Task<TemplateParser> AddTemplateParser(TemplateParser entity, AppUser actor);
        Task<TemplateParser> GetTemplateParser(Type type);

        Task<string> ReviewTemplate(int id, string argument);
        Task<MemoryStream> DownloadReviewTemplate(int id, string argument);
        Task UpdateTemplate(Template template, AppUser actor);
    }
}
