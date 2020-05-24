using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Templates;
using DMCIT.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly AppDbContext _db;
        private readonly IRepository _rep;
        private readonly IServiceProvider _service;

        public TemplateRepository(AppDbContext db, IRepository rep, IServiceProvider service)
        {
            _db = db;
            _rep = rep;
            _service = service;
        }
        public async Task<Template> AddTemplate(Template template, AppUser actor)
        {
            var existance = await _db.Templates.Where(u => u.ModelName == template.ModelName).AnyAsync();
            if (existance)
                return null;

            return await _rep.Add(template, actor);
        }

        public async Task<TemplateParser> AddTemplateParser(TemplateParser template, AppUser actor)
        {
            var existance = await _db.TemplateParsers.Where(u => u.Name == template.Name).AnyAsync();
            if (existance)
            {
                return null;
            }
            var templateType = await _rep.Add(template);
            return templateType;
        }

        public async Task<T> GetParserAsync<T, V>()
            where T : IParser
            where V : ITemplate
        {
            var typeT = typeof(T);
            var lookupType = typeT;
            if (typeT.IsGenericType)
            {
                lookupType = typeT.GetGenericTypeDefinition();
            }

            var tpEntities = await _db.TemplateParsers
       .Where(u => u.ClassName == lookupType.AssemblyQualifiedName)
       .FirstOrDefaultAsync();
            var template = await _db.Templates.FirstOrDefaultAsync(u => u.Name == typeof(V).Name);
            //TODO: create new exception class
            if (template == null)
                throw new Exception("Template not found");
            if (tpEntities == null)
                throw new Exception("Parser not found");

            var p = Activator.CreateInstance<T>();
            p.LoadTemplate(template, _service);
            return p;
        }
        public async Task<IEnumerable<Template>> GetTemplates()
        {
            return await _db.Templates.Include(u => u.TemplateType)
                .Select(u => new Template
                {
                    Name = u.Name,
                    Description = u.Description,
                    Id = u.Id
                })
                .ToListAsync();
        }

        public async Task<Template> GetTemplate(int id)
        {
            return await _db.Templates.Include(u => u.TemplateType).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<TemplateParser> GetTemplateParser(Type type)
        {
            string className = type.AssemblyQualifiedName;
            if (type.IsGenericType)
                className = type.GetGenericTypeDefinition().AssemblyQualifiedName;
            return await _db.TemplateParsers.Where(u => u.ClassName == className).FirstOrDefaultAsync();
        }

        public async Task<string> ReviewTemplate(int id, string argument)
        {
            var template = await GetTemplate(id);
            var parserType = Type.GetType(template.TemplateType.ClassName);
            var inf = parserType.GetInterface(typeof(IParser<,>).Name);

            if (parserType.ContainsGenericParameters)
                throw new ArgumentException("This template cant be preview");
            if (inf == null || inf.GenericTypeArguments.Length < 2)
                throw new ArgumentException("No interface found");

            var argumentType = inf.GenericTypeArguments[0];
            var returnType = inf.GenericTypeArguments[1];

            if (!typeof(string).IsAssignableFrom(argumentType) || !typeof(string).IsAssignableFrom(returnType))
            {
                throw new ArgumentException("This template can not be review");
            }

            var parser = Activator.CreateInstance(parserType) as IParser<string, string>;
            parser.LoadTemplate(template, _service);
            var result = await parser.Parse(argument);
            return result;
        }

        public async Task<MemoryStream> DownloadReviewTemplate(int id, string argument)
        {
            var template = await GetTemplate(id);
            var parserType = Type.GetType(template.TemplateType.ClassName);
            if (parserType == null)
                throw new ArgumentException("No parser found");

            var inf = parserType.GetInterfaces().Where(u => u.IsGenericType && typeof(IParser<string, MemoryStream>) == u).FirstOrDefault();

            if (inf == null || inf.GenericTypeArguments.Length < 2)
                throw new ArgumentException("No interface found");

            var argumentType = inf.GenericTypeArguments[0];
            var returnType = inf.GenericTypeArguments[1];

            if (!typeof(string).IsAssignableFrom(argumentType) || !typeof(MemoryStream).IsAssignableFrom(returnType))
            {
                throw new ArgumentException("This template can not be review");
            }

            var parser = Activator.CreateInstance(parserType) as IParser<string, MemoryStream>;
            parser.LoadTemplate(template, _service);
            var result = await parser.Parse(argument);
            return result;
        }

        public async Task UpdateTemplate(Template template, AppUser actor)
        {
            var entity = await _rep.GetById<Template>(template.Id);
            if (entity == null)
                //TODO: create not found exception
                throw new Exception("Template not found");

            entity.Name = template.Name;
            entity.Description = template.Description;
            entity.Value = template.Value;

            await _rep.Update(entity, actor);
        }
    }
}
