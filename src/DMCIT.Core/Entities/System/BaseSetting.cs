using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DMCIT.Core.Entities.System
{
    public abstract class BaseSetting
    {
        public string GetFullNameWithAssembly()
        {
            var assembly = Assembly.GetExecutingAssembly();
            return $"{GetType().FullName}, {assembly.FullName}";
        }
        public ICollection<Setting> ToSettingEntities()
        {
            var properties = GetType().GetProperties();

            var rs = new List<Setting>();
            foreach (var prop in properties)
            {
                var setting = new Setting();
                object propValue = prop.GetValue(this);
                if (propValue is string)
                    setting.Value = (string)prop.GetValue(this);
                else if (propValue is int)
                    setting.Value = ((int)prop.GetValue(this)).ToString();
                else if (propValue is float || propValue is double)
                {
                    setting.Value = ((double)prop.GetValue(this)).ToString();
                }
                else if (propValue is bool)
                {
                    if ((bool)propValue == true)
                        setting.Value = "1";
                    else
                        setting.Value = "0";
                }
                setting.Name = prop.Name;
                setting.Module = GetFullNameWithAssembly();
                rs.Add(setting);
            }
            return rs;
        }

        public BaseSetting()
        {

        }

        public void LoadFromDb(ICollection<Setting> settings)
        {
            var type = GetType();
            var assembly = Assembly.GetAssembly(typeof(BaseSetting));
            var filter = settings.Where(u => Type.GetType(u.Module) == GetType());

            foreach (var item in filter)
            {
                var prop = type.GetProperty(item.Name);
                if (prop != null)
                {
                    var propType = prop.PropertyType;
                    if (propType == typeof(string))
                    {
                        prop.SetValue(this, item.Value);
                    }
                    else if (propType == typeof(int))
                    {
                        prop.SetValue(this, int.Parse(item.Value));
                    }
                    else if (propType == typeof(double))
                    {
                        prop.SetValue(this, double.Parse(item.Value));
                    }
                    else if (propType == typeof(float))
                    {
                        prop.SetValue(this, float.Parse(item.Value));
                    }
                    else if (propType == typeof(bool))
                    {
                        prop.SetValue(this, item.Value == "1");
                    }
                }
            }
        }
        public abstract void LoadDefault();
    }
}
