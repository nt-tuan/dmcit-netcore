using DMCIT.Core.SharedKernel;

namespace DMCIT.Core.Entities.DataCollector
{
    public class DistributedServerTableDefined : BaseVersionControlEntity<DistributedServerTableDefined>
    {
        public int DistributedServerId { get; set; }
        public DistributedServer DistributedServer { get; set; }
        public string TableName { get; set; }
        public string Query { get; set; }
    }
}
