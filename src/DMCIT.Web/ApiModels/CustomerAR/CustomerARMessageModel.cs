using DMCIT.Core.Entities.Messaging.TemplateMessage;
using DMCIT.Web.ApiModels.Messaging;

namespace DMCIT.Web.ApiModels.CustomerAR
{
    public class CustomerARMessageModel : BaseModel<CustomerARMessage>
    {
        public CustomerARModel customerAR { get; set; }
        public ReceiverProviderModel receiverProvider { get; set; }
        public CustomerARMessageModel()
        {
        }

        public CustomerARMessageModel(CustomerARMessage ar)
        {
            customerAR = new CustomerARModel(ar.CustomerCode, ar.DistributorCode, ar.Amount, ar.At);

            if (ar.Customer != null)
                customerAR.customerName = ar.Customer.GetFullName();

            if (ar.ReceiverProvider != null)
                receiverProvider = new ReceiverProviderModel(ar.ReceiverProvider);
        }
    }
}
