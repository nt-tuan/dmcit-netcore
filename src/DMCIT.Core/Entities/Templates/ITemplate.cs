using System.Collections.Generic;

namespace DMCIT.Core.Entities.Templates
{
    public interface ITemplate
    {
        ICollection<string> GetProperties();
        void Load(string value);
        string GetValue();
    }

    public interface ISystemTemplate
    {
        Template Default();
    }

    public abstract class SystemTemplate<P, Arg, Result> : ITemplate<P>, ISystemTemplate
        where P : IParser<Arg, Result>

    {
        public virtual Template Default()
        {
            var parser = typeof(P);
            var template = new Template
            {
                Name = GetType().Name,
                ModelName = GetType().AssemblyQualifiedName,
                Parser = parser.AssemblyQualifiedName,
                ArgumentModelName = typeof(Arg).AssemblyQualifiedName,
                TemplateType = new TemplateParser
                {
                    ClassName = typeof(P).AssemblyQualifiedName

                },
                Value = GetValue()
            };
            return template;
        }

        public abstract ICollection<string> GetProperties();

        public abstract string GetValue();

        public abstract void Load(string value);
    }

    public interface ITemplate<P> : ITemplate
        where P : IParser
    {

    }
}
