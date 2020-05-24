using System;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.System
{
    public class SettingStore
    {
        IDictionary<Type, BaseSetting> store { get; set; }

        public SettingStore()
        {
            store = new Dictionary<Type, BaseSetting>();
        }

        public void RegisterSetting<T>(BaseSetting setting) where T : BaseSetting
        {
            RegisterSetting(typeof(T), setting);
        }

        public void RegisterSetting(Type type, BaseSetting setting)
        {
            if (store.ContainsKey(type))
                store[type] = setting;
            else
                store.Add(type, setting);
        }

        public T GetSetting<T>() where T : BaseSetting
        {
            if (store.ContainsKey(typeof(T)))
            {
                return (T)store[typeof(T)];
            }
            return null;
        }
    }
}
