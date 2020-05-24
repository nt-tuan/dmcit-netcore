using DMCIT.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMCIT.Web.ApiModels.SupportRequests
{
    public class SREmployeeActionModel : SupportRequestActionModel
    {
        [FromQuery]
        public int employeeId { get; set; }
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var item in base.Validate(validationContext))
            {
                yield return item;
            }
            var core = validationContext.GetService(typeof(ICoreRepository)) as ICoreRepository;
            var entity = core.GetEmployeeById(employeeId).Result;
            if (entity == null)
                yield return new ValidationResult($"Invalid employee #{employeeId}", new string[] { nameof(employeeId) });
        }
    }
}
