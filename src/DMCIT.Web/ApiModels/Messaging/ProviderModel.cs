using DMCIT.Core.Entities.Messaging;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class ProviderModel : BaseModel<MessageServiceProvider>
    {
        public string code { get; set; }
        public string name { get; set; }
        public string label { get; set; }
        public ProviderModel()
        {

        }

        public ProviderModel(MessageServiceProvider entity) : base(entity)
        {
            name = entity.Name;
            code = entity.Code;
            label = entity.AddressLabel;
        }

        public MessageServiceProvider ToEntity()
        {
            var e = new MessageServiceProvider
            {
                Id = id,
                Code = code,
                Name = name,
                AddressLabel = label
            };
            return e;
        }
    }
}
