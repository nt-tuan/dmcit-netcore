using DMCIT.Core.Entities.System;
using DMCIT.Core.SharedKernel;
using System;
using CI = System.Globalization.CultureInfo;

namespace DMCIT.Core.Entities
{
    public class Setting : BaseVersionControlEntity<Setting>
    {
        public string Module { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    }

    public class GeneralSetting : BaseSetting
    {
        public string CultureInfo { get; set; }
        public string NumbericMoneyFormat { get; set; }
        public string ShortDateTimeFormat { get; set; }
        public string LongDateTimeFormat { get; set; }
        public int TimeOffset { get; set; }

        public GeneralSetting()
        {

        }

        public DateTime ParseDateTime(string value)
        {
            var ci = CI.GetCultureInfo(CultureInfo);
            return DateTime.ParseExact(value, ShortDateTimeFormat, ci);
        }

        public override void LoadDefault()
        {
            CultureInfo = "vi-VN";
            NumbericMoneyFormat = "##,#";
            ShortDateTimeFormat = "dd/MM/yyyy";
            LongDateTimeFormat = "HH:mm:ss, dd/MM/yyyy";
            TimeOffset = 7;
        }

    }
}
