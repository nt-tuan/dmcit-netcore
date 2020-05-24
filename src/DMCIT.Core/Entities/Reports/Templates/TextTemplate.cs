using DMCIT.Core.Entities.Templates;
using DMCIT.Core.Entities.Templates.TextParser;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Reports.Templates
{
    public abstract class TextTemplate : SystemTemplate<TextParser, string, string>
    {
        public string content { get; set; }
        public override string GetValue()
        {
            return content;
        }

        public override void Load(string value)
        {
            content = value;
        }

        public override ICollection<string> GetProperties()
        {
            return new List<string>();
        }
    }
}
