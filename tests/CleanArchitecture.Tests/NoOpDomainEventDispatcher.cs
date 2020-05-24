using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using System.Threading.Tasks;

namespace DMCIT.Tests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public async Task DispatchAsync(BaseDomainEvent domainEvent) {
            await Task.Run(() => { });
        }
    }
}
