using MediatR;
using Newtonsoft.Json.Linq;

namespace DMCIT.Core.Events
{
    public abstract class BaseEvent : INotification
    {
        public JObject GetValues()
        {
            var props = GetType().GetProperties();
            var j = new JObject();
            foreach (var p in props)
            {
                var pName = p.Name;
                var pType = p.PropertyType;
                var pValue = p.GetValue(this);
                if (pType.IsPrimitive || typeof(string).IsAssignableFrom(pType))
                {
                    j.Add(pName, new JValue(pValue));
                }
                else if (typeof(JObject).IsAssignableFrom(pType))
                {
                    j.Add(pName, (JObject)pValue);
                }
            }
            return j;
        }
    }
}
