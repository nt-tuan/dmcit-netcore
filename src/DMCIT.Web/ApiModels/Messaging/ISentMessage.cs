using DMCIT.Core.Entities.Messaging;

namespace DMCIT.Web.ApiModels.Messaging
{
    public interface ISentMessage
    {
        SentMessage ToSentMessage();
    }
}
