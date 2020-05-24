using DMCIT.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMCIT.Web.ApiModels.SupportRequests
{
    public class SupportRequestActionModel : IValidatableObject
    {
        public int id { get; set; }
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var rep = validationContext.GetService(typeof(ISupportRequestRepository)) as ISupportRequestRepository;
            if (rep == null)
                yield return ValidationResult.Success;
            var sr = rep.GetRequestById(id);
            if (sr == null)
                yield return new ValidationResult("Invalid support request", new string[] { "id" });
        }
    }
}
