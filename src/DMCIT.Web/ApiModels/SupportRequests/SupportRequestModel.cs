using DMCIT.Core.Entities.SupportRequests;
using DMCIT.Web.ApiModels.HR;
using DMCIT.Web.ApiModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DMCIT.Web.ApiModels.SupportRequests
{
    public class SupportRequestSummaryModel
    {
        public int id { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
        public DateTime modifyTime { get; set; }
        public string status { get; set; }
        public int employeeId { get; set; }
        public EmployeeModel requester { get; set; }
        public EmployeeModel handler { get; set; }
        public List<string> tags { get; set; }
        public int? assignedToId { get; set; }
        public int? assignedById { get; set; }
        public bool isPublic { get; set; }
        public SupportRequestSummaryModel(SupportRequest sr)
        {
            id = sr.GetId();
            subject = sr.Subject;
            content = sr.Post?.Content;
            modifyTime = sr.DateCreated;
            status = sr.Status.ToString();
            employeeId = sr.RequesterId;
            assignedToId = sr.AssignedToId;
            assignedById = sr.AssignedById;
            if (sr.Requester != null)
                requester = new EmployeeModel(sr.Requester);
            if (sr.AssignedTo != null)
                handler = new EmployeeModel(sr.AssignedTo);
        }
    }

    public class SupportRequestDetailModel : SupportRequestSummaryModel
    {
        public PostDetailModel post { get; set; }
        public List<SRActionModel> actions { get; set; }
        public SupportRequestDetailModel(SupportRequest sr) : base(sr)
        {
            if (sr.Post != null)
            {
                post = new PostDetailModel(sr.Post);
            }
            if (sr.Versions != null)
            {
                actions = sr.Versions.Select(u => new SRActionModel(u)).ToList();
            }
        }
    }
}
