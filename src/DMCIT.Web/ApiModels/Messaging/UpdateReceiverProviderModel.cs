using DMCIT.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class UpdateReceiverProviderModel : IValidatableObject
    {
        public int receiverId { get; set; }
        public ProviderModel provider { get; set; }
        public string receiverAddress { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var noProvider = new ValidationResult("NO PROVIDER");
            if (provider == null)
            {
                yield return noProvider;
            }

            if (string.IsNullOrEmpty(receiverAddress))
            {
                yield return new ValidationResult("NO ADDRESSEE");
            }


            var sale = validationContext.GetService(typeof(IMessageReceiverRepository)) as IMessageReceiverRepository;

            var eProvider = (sale.GetProviderById(provider.id, false)).Result;
            if (eProvider == null)
                yield return noProvider;

            if (!Regex.IsMatch(receiverAddress, eProvider.AddressRegex))
            {
                yield return new ValidationResult($"INVALID ADDRESSEE, IT HAS TO MATCH {eProvider.AddressRegex}");
            }

        }
    }
}
