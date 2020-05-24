using DMCIT.Core.Entities.Reports;

namespace DMCIT.Web.ApiModels.CustomerAR
{
    public class CustomerPaymentModel : CustomerARModel
    {
        public decimal arAmount { get; set; }
        public CustomerPaymentModel(CustomerPayment entity)
        {
            customerCode = entity.CustomerCode;
            customerName = entity.Customer == null ? null : entity.Customer.GetFullName();
            distributorCode = entity.DistributorCode;
            createdDate = entity.ReceiptDate;
            amount = entity.Amount;
            arAmount = entity.ARAmount ?? 0;
        }
    }
}
