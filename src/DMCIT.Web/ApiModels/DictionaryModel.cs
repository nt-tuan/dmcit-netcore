using System.Collections.Generic;

namespace DMCIT.Web.ApiModels
{
    public class DictionaryModel
    {
        public Dictionary<string, string> dictionary { get; set; } = new Dictionary<string, string>();

        public IDictionary<string, string> GetValue()
        {
            return dictionary;
        }
    }
}
