using DMCIT.Core.SharedKernel;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAsync(BaseDomainEvent domainEvent);
    }
}