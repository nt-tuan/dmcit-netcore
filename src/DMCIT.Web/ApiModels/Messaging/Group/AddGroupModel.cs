using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DMCIT.Web.ApiModels.Messaging.Group
{
    public class AddGroupModel : GroupModel, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (name == null || name.Length < _minNameLength || name.Length > _maxNameLength)
            {
                yield return new ValidationResult($"GROUP NAME MUST HAVE FROM {_minNameLength} TO {_maxNameLength} CHARACTERS", new[] { "name" });
            }
        }
    }
}
