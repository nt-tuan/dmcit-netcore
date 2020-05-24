
using DMCIT.Core.SharedKernel;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.DataCollector
{
    public class DistributedServer : BaseVersionControlEntity<DistributedServer>
    {
        public string DistributorCode { get; set; }
        public string Servername { get; set; }
        public string Description { get; set; }
        public string ConnectionString { get; set; }

        public ICollection<DistributedServerTableDefined> DistributedServerTableDefineds { get; set; }

        public override string ToString()
        {
            return $"{Servername} (#{DistributorCode})";
        }
    }
}
