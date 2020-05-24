using DMCIT.Core.SharedKernel;
using System;

namespace DMCIT.Core.Entities.Core
{
    public class AccountingPeriod : BaseVersionControlEntity<AccountingPeriod>
    {
        public string Name { get; set; }
        public DateTime? AccountingStartTime { get; set; }
        public DateTime AccountingEndTime { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }
    }
}
