using DMCIT.Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Providers
{
    public class Test : IMessagingProvider
    {
        public ILogger _logger;
        public Test(ILogger<IMessagingRepository> logger)
        {
            _logger = logger;
        }

        public Test()
        {

        }

        public async Task<SendMessageResult> SendMessage(string content, string addressee)
        {
            var rs = await Task.Run(() =>
            {
                _logger.LogInformation($"Send message: \"{content}\" to {addressee}");

                Task.Delay(200);
                return new SendMessageResult
                {
                    Success = true,
                    ResponseMessage = "This is just write to log",
                    Addressee = addressee,
                    Content = content
                };
            });

            return rs;
        }

        public async Task<SendMessageResult> SendMessage(string content, string[] address)
        {
            foreach (var item in address)
            {
                Task task = new Task(() =>
                {
                    _logger.LogInformation($"Send message: \"{content}\" to {item}");
                });
                await task;
            }
            return new SendMessageResult
            {
                Success = true,
                ResponseMessage = "This is just write to log"
            };
        }

        public Task<SendMessageResult> SendMessage(string content, string address, string contentType)
        {
            throw new NotImplementedException();
        }

        public Task<SendMessageResult> SendMessage(string content, string[] address, string contentType)
        {
            throw new NotImplementedException();
        }
    }
}
