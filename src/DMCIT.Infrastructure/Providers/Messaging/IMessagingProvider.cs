using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Providers
{
    public interface IMessagingProvider
    {
        Task<SendMessageResult> SendMessage(string content, string address);
        Task<SendMessageResult> SendMessage(string content, string[] address);
        Task<SendMessageResult> SendMessage(string content, string address, string contentType);
        Task<SendMessageResult> SendMessage(string content, string[] address, string contentType);
    }
}
