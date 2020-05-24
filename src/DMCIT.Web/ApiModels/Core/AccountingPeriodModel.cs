using DMCIT.Core.Entities.Core;
using System;

namespace DMCIT.Web.ApiModels.Core
{
    public class AccountingPeriodModel : BaseModel<AccountingPeriod>
    {
        public string name { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool opened { get; set; }
        public bool closed { get; set; }

        public AccountingPeriodModel()
        {

        }

        public AccountingPeriodModel(AccountingPeriod e) : base(e)
        {
            name = e.Name;
            startTime = e.AccountingStartTime;
            endTime = e.AccountingEndTime;
            opened = e.OpenTime != null;
            closed = e.CloseTime != null;
        }

        public AccountingPeriod ToEntity()
        {
            var entity = new AccountingPeriod
            {
                Id = id,
                Name = name,
                AccountingEndTime = endTime,
                AccountingStartTime = startTime
            };
            return entity;
        }
    }
}
