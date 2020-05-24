using DMCIT.Core.Entities.DataCollector;

namespace DMCIT.Web.ApiModels.DataCollector
{
    public class DistributedServerModel
    {
        public string distributorCode { get; set; }
        public string servername { get; set; }
        public string description { get; set; }
        public string connectionString { get; set; }

        public DistributedServer ToEntity()
        {
            var e = new DistributedServer
            {
                DistributorCode = distributorCode,
                Description = description,
                Servername = servername,
                ConnectionString = connectionString
            };
            return e;
        }
    }
}
