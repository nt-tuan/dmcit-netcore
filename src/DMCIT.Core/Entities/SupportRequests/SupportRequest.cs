using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Posts;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;


namespace DMCIT.Core.Entities.SupportRequests
{
    public class SupportRequest : BaseVersionControlEntity<SupportRequest>
    {
        public static string MANAGER_ROLE = "SupportRequest.Manager";
        public static string SUPPORTER_ROLE = "SupportRequest.Supporter";
        public enum SupportRequestRoles { ANONYMOUS, PIC, MANAGER, SPECIALIST, REQUESTOR, ASSIGNER, CREATOR }
        public enum RequestStatus { ASSIGNING, PENDING, HANDLING, CONFIRMING, DONE, CLOSE }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RequestStatusNumber { get; set; }
        public RequestStatus Status
        {
            get
            {
                return (RequestStatus)RequestStatusNumber;
            }
            set
            {
                RequestStatusNumber = (int)value;
            }
        }
        public string Conlusion { get; set; }
        public string ConfirmFinishCode { get; set; }
        public int RequesterId { get; set; }
        public Employee Requester { get; set; }
        public int? AssignedById { get; set; }
        public Employee AssignedBy { get; set; }
        public int? AssignedToId { get; set; }
        public Employee AssignedTo { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public DateTime? AssignedTime { get; set; }
        public DateTime? HandleTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public DateTime? ConfirmTime { get; set; }
        public ICollection<SupportAssistant> SupportAssistants { get; set; }
        public void ToNewSupportRequest(Employee emp)
        {
            //TODO: set to new SupportRequest
            Status = RequestStatus.ASSIGNING;
            RequesterId = emp.GetId();
            Conlusion = null;
            ConfirmFinishCode = null;
            AssignedById = null;
            AssignedToId = null;
        }
    }
}
