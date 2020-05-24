using DMCIT.Core.Entities;

namespace DMCIT.Web.ApiModels.System
{
    public class SettingModel
    {
        public string name { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        public string summary { get; set; }

        public SettingModel()
        {

        }

        public SettingModel(Setting setting)
        {
            name = setting.Name;
            value = setting.Value;
            description = setting.Description;
            summary = setting.Summary;
        }
    }
}
