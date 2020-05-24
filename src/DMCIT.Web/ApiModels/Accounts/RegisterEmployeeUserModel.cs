using DMCIT.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMCIT.Web.ApiModels.Accounts
{
    public class RegisterEmployeeUserModel
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public int employeeId { get; set; }
    }

    public class RegisterEmployeeUserAnonymouseModel : IValidatableObject
    {
        [Required]
        public string password { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [Phone]
        public string phone { get; set; }
        [Required]
        public string employeeCode { get; set; }
        [Required]
        public DateTime birthday { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var core = validationContext.GetService(typeof(ICoreRepository)) as ICoreRepository;
            var employee = core.GetEmployeeByCode(employeeCode).Result;
            if (employee == null)
                yield return new ValidationResult("EMPLOYEE NOT FOUND", new[] { nameof(employeeCode) });
            var person = core.GetPersonById(employee.PersonId).Result;
            if (person == null || person.Birthday == null)
            {
                yield return new ValidationResult("EMPLOYEE IS NOT DECLARED PERSONAL INFORMATION, PLEASE CONTACT ADMIN", new[] { nameof(employeeCode) });
            }
            if (person.Birthday.Value.Date != birthday.Date)
            {
                yield return new ValidationResult("EMPLOYEE CODE AND BIRTHDAY DO NOT MATCH", new[] { nameof(employeeCode), nameof(birthday) });
            }
        }
    }
}
