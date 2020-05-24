using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.SupportRequests;
using MediatR;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Services
{
    public interface ISupportRequestService
    {
        Task OnStatusChange(SupportRequest supportRequest, SupportRequest.RequestStatus old, AppUser actor);
    }

    public class SupportRequestService : ISupportRequestService
    {
        private readonly IMediator _mediator;
        public SupportRequestService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task OnStatusChange(SupportRequest supportRequest, SupportRequest.RequestStatus old, AppUser actor)
        {

        }
    }
}
