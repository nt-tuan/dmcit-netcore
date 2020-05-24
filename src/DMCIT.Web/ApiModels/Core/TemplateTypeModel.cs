using DMCIT.Core.Entities.Templates;

namespace DMCIT.Web.ApiModels.Core
{
    public class TemplateTypeModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string fullname { get; set; }

        public TemplateTypeModel() { }
        public TemplateTypeModel(TemplateParser entity)
        {
            id = entity.Id;
            name = entity.Name;
            fullname = entity.ClassName;
        }
    }
}
