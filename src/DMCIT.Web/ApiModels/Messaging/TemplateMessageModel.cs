using System.Collections.Generic;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class TemplateMessageModel
    {
        public string source { get; set; }
        Dictionary<string, object> parameters { get; set; }
    }
}
