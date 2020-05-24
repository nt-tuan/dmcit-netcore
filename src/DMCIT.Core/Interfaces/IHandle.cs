using DMCIT.Core.SharedKernel;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}