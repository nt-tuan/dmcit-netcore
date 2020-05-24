namespace DMCIT.Infrastructure.Providers
{
    public class SendMessageResult
    {
        public bool Success { get; set; }
        public string ResponseMessage { get; set; }
        public string Content { get; set; }
        public string Addressee { get; set; }
    }
}
