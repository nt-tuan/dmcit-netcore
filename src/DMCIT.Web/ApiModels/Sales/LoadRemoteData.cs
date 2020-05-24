using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMCIT.Web.ApiModels.Sales
{
    public class LoadRemoteDataModel : IValidatableObject
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<string> distributors { get; set; }

        public LoadRemoteDataModel()
        {
            startDate = startDate.ToLocalTime();
            endDate = endDate.ToLocalTime();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (distributors == null || distributors.Count == 0)
            {
                yield return new ValidationResult("NO SERVERS SELECTED");
            }

            if (endDate < startDate)
            {
                yield return new ValidationResult("INVALID DATE RANGE");
            }
        }
    }
}
