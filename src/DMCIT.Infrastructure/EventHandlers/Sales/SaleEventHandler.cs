using DMCIT.Core.Entities.Sales;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Events.Core;
using DMCIT.Infrastructure.Events.Sales;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.DomainEvents.Handlers.Sales
{
    public class SaleEventHandler : INotificationHandler<OnBusinessUpdatedEvent>,
        INotificationHandler<OnPersonUpdatedEvent>,
        INotificationHandler<OnCustomerCreatedEvent>,
        INotificationHandler<OnCustomerUpdatedEvent>
    {
        private ISaleRepository _sale;
        private ICoreRepository _core;
        private IRepository _rep;
        public SaleEventHandler(IRepository rep, ISaleRepository sale, ICoreRepository core)
        {
            _sale = sale;
            _core = core;
            _rep = rep;
        }

        async Task cacheCustomerProperties(Customer e)
        {
            e.RemoveCache();
            if (e.BusinessId != null)
            {
                //Remove person foreign keys
                e.PersonId = null;
                var business = await _core.GetBusinessById(e.BusinessId.Value);
                if (business == null)
                    e.BusinessId = null;
                else
                {
                    e.Cache(business);
                }
            }
            else if (e.PersonId != null)
            {
                e.BusinessId = null;
                var person = await _core.GetPersonById(e.PersonId.Value);
                if (person == null)
                    e.PersonId = null;
                else
                    e.Cache(person);
            }
            await _rep.UpdateSilently(e);
        }

        public async Task Handle(OnCustomerUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var e = notification.Entity;
            await cacheCustomerProperties(e);
        }

        public async Task Handle(OnBusinessUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var param = new GetListParams<Customer>();
            param.SetGetAllItems();
            param.extension = query => query.Where(u => u.BusinessId == notification.Entity.GetId());
            var customers = await _sale.GetCustomers(param);
            foreach (var item in customers)
            {
                await cacheCustomerProperties(item);
            }
        }

        public async Task Handle(OnPersonUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var param = new GetListParams<Customer>();
            param.SetGetAllItems();
            param.extension = query => query.Where(u => u.PersonId == notification.Entity.GetId());
            var customers = await _sale.GetCustomers(param);
            foreach (var item in customers)
            {
                await cacheCustomerProperties(item);
            }
        }

        public async Task Handle(OnCustomerCreatedEvent notification, CancellationToken cancellationToken)
        {
            await cacheCustomerProperties(notification.Entity);
        }
    }
}
