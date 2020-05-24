using DMCIT.Core.Entities;
using Helper;

namespace DMCIT.Web.ApiModels.System
{
    public class GeneralSettingModel
    {
        public string CultureInfo { get; set; }
        public string NumbericMoneyFormat { get; set; }
        public string ShortDateTimeFormat { get; set; }
        public string LongDateTimeFormat { get; set; }
        public int TimeOffset { get; set; }
        public GeneralSettingModel(GeneralSetting setting)
        {
            UtilityHelper.Copy(setting, this);
        }

        public GeneralSettingModel()
        {
        }

        public GeneralSetting ToEntity()
        {
            var e = new GeneralSetting();
            UtilityHelper.Copy(this, e);
            return e;
        }
    }
}
