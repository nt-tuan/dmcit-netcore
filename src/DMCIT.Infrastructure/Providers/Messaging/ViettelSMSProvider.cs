using DMCIT.Core.Entities.Messaging.Settings;
using DMCIT.Core.Interfaces;
using SMSViettelService;
using System;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Providers
{
    public class ViettelSMSProvider : IMessagingProvider
    {
        private readonly ISettingRepository _setting;
        public ViettelSMSProvider(ISettingRepository setting)
        {
            _setting = setting;
        }

        public async Task<SendMessageResult> SendMessage(string content, string addressee)
        {
            var sendResult = new SendMessageResult
            {
                Addressee = addressee,
                Content = content
            };
            try
            {
                //TODO: hardcode disable this provider
                throw new System.Exception("This provider is disabled in this version");

                var s = _setting.GetSettingStore().GetSetting<ViettelSMSSetting>();
                CcApiClient client = new CcApiClient();
                if (!s.Active)
                {
                    //TODO: create exception class
                    throw new System.Exception("This provider is not active yet");
                }
                var r = await client.wsCpMtAsync(s.Username, s.Password, s.CPCode, s.RequestID, addressee, addressee, s.ServiceID, s.CommandCode, content, s.ContentType);

                if (r.@return.result1 == 1)
                {
                    sendResult.ResponseMessage = "Gửi tin thành công!. Error code:" + r.@return.message;
                    sendResult.Success = true;
                }
                else
                {
                    sendResult.ResponseMessage = "Gửi tin thất bại!. Error code:" + r.@return.message;
                    sendResult.Success = false;
                }
            }
            catch (System.Exception ex)
            {
                sendResult.ResponseMessage = "Đã có lỗi xảy ra! Error: " + ex.ToString();
                sendResult.Success = false;
            }
            return sendResult;
        }

        public Task<SendMessageResult> SendMessage(string content, string[] address)
        {
            throw new NotImplementedException();
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
