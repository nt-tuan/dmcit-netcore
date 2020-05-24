using Newtonsoft.Json;

namespace DMCIT.Core.Entities.Templates.TextParser
{
    public class SerializedObject
    {
        public string GetValue()
        {
            return JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public void LoadData(string data)
        {
            var source = JsonConvert.DeserializeObject(data, GetType(), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            var props = GetType().GetProperties();
            foreach (var p in props)
            {
                var sourceValue = p.GetValue(source);
                p.SetValue(this, sourceValue);
            }
        }
    }
}
