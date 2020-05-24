using System;
using System.Threading.Tasks;

namespace DMCIT.Core.Entities.Templates
{
    public interface IParser
    {
        void LoadTemplate(Template template, IServiceProvider serviceProvider);
    }

    public interface IParser<T, Result> : IParser
    {
        Task<Result> Parse(T argumentsModel);
    }
}
