using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMCIT.Core.Entities.Templates.TextParser
{
    public class TextParser : IParser<string, string>
    {
        private string template { get; set; }
        public void LoadTemplate(Template template, IServiceProvider serviceProvider)
        {
            this.template = template.Value;
        }

        public async Task<string> Parse(string arg)
        {
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(arg);
            var builder = new StringBuilder(template);
            foreach (var item in dict)
            {
                builder.Replace("{" + item.Key + "}", item.Value);
            }
            return builder.ToString();
        }
    }
}
