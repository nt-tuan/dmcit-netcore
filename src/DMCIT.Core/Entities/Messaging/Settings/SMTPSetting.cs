using DMCIT.Core.Entities.System;

namespace DMCIT.Core.Entities.Messaging.Settings
{
    public class SMTPSetting : BaseSetting
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool EnableSsl { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool IsBodyHtml { get; set; }
        public override void LoadDefault()
        {
            IsBodyHtml = true;
            Password = "Nttuan!1881376";
            User = "tuannt@domesco.com";
            EnableSsl = false;
            Port = 25;
            Host = "mail.domesco.com";
        }
    }
}
