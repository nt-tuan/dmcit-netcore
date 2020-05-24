using DMCIT.Core.Entities.Reports;
using DMCIT.Infrastructure.Data;
using DMCIT.Infrastructure.Events.CustomerAREvent;
using EFCore.BulkExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DMCIT.Web.EventHandlers
{
    public class CustomterARHandler : INotificationHandler<EndCalculatedCustomerAREvent>
    {
        readonly AppDbContext _db;
        public CustomterARHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task Handle(EndCalculatedCustomerAREvent notification, CancellationToken cancellationToken)
        {
            var ls = notification.ARs.Select(u => new CustomerARNow
            {
                CustomerId = u.CustomerId,
                CreatedDate = u.CreatedDate,
                CustomerCode = u.CustomerCode,
                DistributorCode = u.DistributorCode,
                Amount = u.Amount
            });

            await _db.BulkDeleteAsync(await _db.CustomerARNows.ToListAsync());
            await _db.BulkInsertAsync(ls.ToList());
        }
    }
}
