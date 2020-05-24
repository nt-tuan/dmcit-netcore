using DMCIT.Core.Entities.System;

namespace DMCIT.Core.Entities.Reports
{
    public class CustomerPaymentSetting : BaseSetting
    {
        public int ExcelExporterFirstColumn { get; set; }
        public int ExcelExporterFirstRow { get; set; }
        public int ExcelExporterHeaderRowCount { get; set; }
        public int ExcelExporterSheetIndex { get; set; }
        public string ExcelExporterSheetName { get; set; }
        public string ExcelExporterTemplateFilePath { get; set; }

        public CustomerPaymentSetting() : base() { }

        public override void LoadDefault()
        {
            ExcelExporterFirstColumn = 0;
            ExcelExporterFirstRow = 0;
            ExcelExporterHeaderRowCount = 1;
            ExcelExporterSheetIndex = 0;
            ExcelExporterSheetName = "Payments";
        }
    }
}
