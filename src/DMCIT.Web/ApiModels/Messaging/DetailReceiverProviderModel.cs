using DMCIT.Core.Entities.Messaging;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class DetailReceiverProviderModel : ReceiverProviderModel
    {
        public MessageReceiverModel receiver { get; set; }
        public DetailReceiverProviderModel()
        {

        }

        public DetailReceiverProviderModel(ReceiverProvider entity) : base(entity)
        {
            if (entity.MessageReceiver != null)
                receiver = new MessageReceiverModel(entity.MessageReceiver);
        }


    }
}
