using System;
using System.Collections.Generic;

namespace DMCIT.Core.SharedKernel
{
    public class BaseVersionControlEntity<T> : BaseEntity
    {
        public DateTime DateEffective { get; set; }
        public DateTime? DateEnd { get; set; }
        public DateTime? DateReplaced { get; set; }
        public string DiscriptionNote { get; set; }
        public int? OriginId { get; set; }
        public T Origin { get; set; }
        public ICollection<T> Versions { get; set; }

        public int GetId()
        {
            return OriginId ?? Id;
        }

        public string GetPrefix<V>()
        {
            var prefix = "Cache" + typeof(V).Name;
            return prefix;
        }

        public void Cache<V>(V entity)
        {
            var prefix = GetPrefix<V>();
            var props = entity.GetType().GetProperties();
            foreach (var item in props)
            {
                var pValue = item.GetValue(entity);
                var thisProp = GetType().GetProperty(prefix + item.Name);
                if (thisProp == null)
                    continue;
                try
                {
                    thisProp.SetValue(this, pValue);
                }
                catch
                {
                }
            }
        }

        public V RetreiveCache<V>()
        {
            var prefix = GetPrefix<V>();
            var props = GetType().GetProperties();
            var rs = Activator.CreateInstance<V>();
            foreach (var item in props)
            {
                var pName = item.Name;
                if (!pName.StartsWith(prefix))
                    continue;

                var rsPropName = pName.Substring(prefix.Length);
                var rsProp = rs.GetType().GetProperty(rsPropName);
                if (rsProp == null)
                    continue;

                rsProp.SetValue(rs, item.GetValue(this));
            }

            return rs;
        }

        public static Type[] DefaultDuplicateType = { typeof(string), typeof(DateTime), typeof(DateTime?) };

        public virtual object Dupplicate()
        {
            var obj = Activator.CreateInstance(GetType());
            var props = GetType().GetProperties();
            foreach (var prop in props)
            {
                var pType = prop.PropertyType;
                var valid = false;
                valid = valid || pType.IsPrimitive;
                foreach (var item in DefaultDuplicateType)
                {
                    valid = valid || item.IsAssignableFrom(pType);
                }
                if (pType.IsGenericType && pType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    var args = pType.GetGenericArguments();
                    if (args.Length > 0)
                    {
                        valid = valid || args[0].IsPrimitive;
                    }
                }
                if (!valid) continue;
                var pValue = prop.GetValue(this);
                prop.SetValue(obj, pValue);
            }
            return obj;
        }

        public virtual bool HasChange(T dest)
        {
            return true;
        }
    }
}
