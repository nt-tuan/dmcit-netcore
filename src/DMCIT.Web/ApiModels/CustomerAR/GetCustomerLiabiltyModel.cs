using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMCIT.Web.ApiModels.Sales
{
    public class GetCurrentCustomerLiabiltyModel : IValidatableObject
    {
        public ICollection<int> distributors { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (distributors == null || distributors.Count == 0)
            {
                yield return new ValidationResult("Chi nhánh không hợp lệ", new[] { "distributors" });
            }
        }
    }
}
