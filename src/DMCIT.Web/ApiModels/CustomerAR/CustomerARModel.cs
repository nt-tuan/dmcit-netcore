using DMCIT.Core.Entities.Reports;
using System;

namespace DMCIT.Web.ApiModels.CustomerAR
{
    public class CustomerARModel : BaseModel<DMCIT.Core.Entities.Reports.CustomerAR>
    {
        public string customerCode { get; set; }
        public string customerName { get; set; }
        public string distributorCode { get; set; }
        public DateTime? createdDate
        {
            get; set;
        }
        public decimal amount { get; set; }

        public CustomerARModel() { }
        public CustomerARModel(CustomerARNow entity)
        {
            customerCode = entity.CustomerCode;
            if (entity.Customer != null)
            {
                if (entity.Customer.Business != null)
                {
                    customerName = entity.Customer.GetDisplayName();
                }
                else if (entity.Customer.GetDisplayName() != null)
                {
                    customerName = entity.Customer.GetDisplayName();
                }
            }
            distributorCode = entity.DistributorCode;
            amount = entity.Amount;
            createdDate = entity.CreatedDate;
        }

        public CustomerARModel(string customer, string distributor, decimal amount, DateTime? at)
        {
            customerCode = customer;
            distributorCode = distributor;
            this.amount = amount;
            createdDate = at;
        }
    }
}
