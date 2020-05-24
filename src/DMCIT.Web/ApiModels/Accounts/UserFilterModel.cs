using DMCIT.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DMCIT.Web.ApiModels.Accounts
{
    public class UserFilterModel : FilterModel<AppUser>
    {
        public List<string> roles { get; set; }
        public override Expression<Func<AppUser, object>> BuildOrder(string orderBy, int? orderDir)
        {
            return u => u.UserName;
        }

        public override IQueryable<AppUser> BuildQuery(IQueryable<AppUser> query)
        {
            return query;
        }

        public override IQueryable<AppUser> BuildSearchQuery(IQueryable<AppUser> q)
        {
            return q;
        }
    }
}
