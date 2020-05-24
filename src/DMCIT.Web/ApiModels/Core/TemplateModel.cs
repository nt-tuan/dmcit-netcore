using DMCIT.Core.Entities.Templates;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace DMCIT.Web.ApiModels.Core
{
    public class TemplateModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string modelName { get; set; }
        public string description { get; set; }
        public bool downloadable { get; set; }
        public object value { get; set; }
        public bool reviewable { get; set; }
        public TemplateModel() { }

        public TemplateModel(Template template)
        {
            id = template.Id;
            name = template.Name;
            modelName = template.ModelName;
            description = template.Description;
            if (template.TemplateType == null)
                return;

            value = template.GetModelObject();
            var parserType = Type.GetType(template.TemplateType.ClassName);
            loadAbility(parserType);
        }

        public void loadAbility(Type parserType)
        {
            downloadable = false;
            reviewable = false;
            if (parserType == null)
            {
                downloadable = false;
                reviewable = false;
                return;
            }
            var allInfs = parserType.GetInterfaces();
            var infs = allInfs.Where(u => u.IsGenericType && typeof(IParser<,>) == u.GetGenericTypeDefinition());
            foreach (var inf in infs)
            {
                var validInf = inf != null && inf.GenericTypeArguments.Length == 2;
                downloadable = downloadable || (validInf && typeof(Stream).IsAssignableFrom(inf.GenericTypeArguments[1]));
                reviewable = reviewable || (validInf && typeof(string).IsAssignableFrom(inf.GenericTypeArguments[1]));
            }
        }

        public Template ToEntity()
        {
            var template = new Template
            {
                Id = id,
                Name = name,
                ModelName = modelName,
                Description = description,
                Value = JsonConvert.SerializeObject(value)
            };
            return template;
        }
    }
}
