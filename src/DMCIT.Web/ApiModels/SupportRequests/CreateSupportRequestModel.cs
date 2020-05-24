using DMCIT.Core.Entities.SupportRequests;
using DMCIT.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMCIT.Web.ApiModels.SupportRequests
{
    public class CreateSupportRequestModel
    {
        [MinLength(16)]
        public string content { get; set; }
        [MinLength(3)]
        public string subject { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Phone]
        public string phone { get; set; }

        public SupportRequest CreateNewSupportRequest()
        {
            var sr = new SupportRequest();
            sr.Email = email;
            sr.Phone = phone;
            sr.Subject = subject;
            var post = new DMCIT.Core.Entities.Posts.Post();
            post.Content = content;
            post.Subject = subject;
            sr.Post = post;
            return sr;
        }
    }
    public class CreateSupportRequestModelFor : CreateSupportRequestModel, IValidatableObject
    {
        [Required]
        public int employeeId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var _hr = validationContext.GetService(typeof(ICoreRepository)) as ICoreRepository;
            var emp = _hr.GetEmployeeById(employeeId).Result;
            if (emp == null)
                yield return new ValidationResult("INVALID EMPLOYEE");
        }
    }
}
