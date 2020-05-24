using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class SendCustomerLiabilityMessageModel : IValidatableObject
    {
        public ICollection<int> distributors { get; set; }
        public ICollection<int> providers { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (distributors == null || distributors.Count == 0)
            {
                yield return new ValidationResult("Chi nhánh không hợp lệ");
            }
            if (providers == null || providers.Count == 0)
            {
                yield return new ValidationResult("Nhà cung cấp dịch vụ tin nhắn không hợp lệ");
            }
        }
    }
}
