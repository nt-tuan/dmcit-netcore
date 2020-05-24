using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMCIT.Web.ApiModels.Sales
{
    public class GetCustomerPaymentModel : IValidatableObject
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int[] distributors { get; set; }
        public int[] providers { get; set; }

        public GetCustomerPaymentModel()
        {
        }

        public void ChangeToLocalTime()
        {
            startDate = startDate.ToLocalTime();
            endDate = endDate.ToLocalTime();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (startDate > endDate)
            {
                yield return new ValidationResult("Thời gian không hợp lệ", new[] { "startDate", "endDate" });
            }

            if (endDate - startDate > TimeSpan.FromDays(7))
            {
                yield return new ValidationResult("Khoảng thời gian tối đa là 7 ngày");
            }

            if (distributors == null || distributors.Length == 0)
            {
                yield return new ValidationResult("Chi nhánh không hợp lệ", new[] { "distributors" });
            }
        }
    }
}
