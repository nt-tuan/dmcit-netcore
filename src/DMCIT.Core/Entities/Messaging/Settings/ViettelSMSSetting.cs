using DMCIT.Core.Entities.System;

namespace DMCIT.Core.Entities.Messaging.Settings
{
    public class ViettelSMSSetting : BaseSetting
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string CPCode { get; set; }
        public string RequestID { get; set; }
        public string ServiceID { get; set; }
        public string CommandCode { get; set; }
        public string ContentType { get; set; }
        public bool Active { get; set; }

        public ViettelSMSSetting() { }

        public override void LoadDefault()
        {
            Username = "smsbrand_domesco";
            Password = "123456aA@";
            CPCode = "DOMESCO";
            ServiceID = "DOMESCO";
            CommandCode = "bulksms";
            RequestID = "1";
            ContentType = "1";
            Active = true;
        }
    }
}
