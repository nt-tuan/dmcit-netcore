using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Messaging
{
    public class MessageBatch : BaseEntity
    {
        public int? AutoMessageConfigId { get; set; }
        public AutoMessageConfig AutoMessageConfig { get; set; }
        public DateTime? ActionTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public MessageSource MessageSource { get; set; }
        public int? MessageSourceId { get; set; }

        public ICollection<SentMessage> SentMessages { get; set; }
    }
}
