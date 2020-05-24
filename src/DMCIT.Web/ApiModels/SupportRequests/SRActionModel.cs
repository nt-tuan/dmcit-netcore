using DMCIT.Core.Entities.SupportRequests;
using DMCIT.Web.ApiModels.Accounts;
using System;

namespace DMCIT.Web.ApiModels.SupportRequests
{
    public class SRActionModel
    {
        public int type { get; set; }
        public DateTime time { get; set; }
        public UserModel by { get; set; }

        public SRActionModel(SupportRequest sr)
        {
            type = sr.RequestStatusNumber;
            time = sr.DateCreated;
            if (sr.CreatedBy != null)
                by = new UserModel(sr.CreatedBy);
        }
    }
}
