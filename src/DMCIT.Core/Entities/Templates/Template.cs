using DMCIT.Core.SharedKernel;
using System;

namespace DMCIT.Core.Entities.Templates
{
    public class Template : BaseEntity
    {
        public string Name { get; set; }
        public string ModelName { get; set; }
        public string ArgumentModelName { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public string Parser { get; set; }
        public int TemplateTypeId { get; set; }
        public TemplateParser TemplateType { get; set; }
        public Template() { }
        public Template(Type type, string value, string description)
        {
            ModelName = type.FullName;
            Name = type.Name;
            Description = description;
            Value = value;
        }

        public object GetModelObject()
        {
            var modelType = Type.GetType(ModelName);
            var obj = Activator.CreateInstance(modelType) as ITemplate;
            obj.Load(Value);
            return obj;
        }
    }
}
