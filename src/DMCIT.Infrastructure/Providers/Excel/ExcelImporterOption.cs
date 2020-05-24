using DMCIT.Core.Entities.Templates;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DMCIT.Infrastructure.Providers.Excel
{
    public abstract class ExcelImporterOption<Element> : SystemTemplate<ExcelImporter<Element>, Stream, List<Element>>
    where Element : IExcelImportableObject
    {
        public string filePath { get; set; }
        public int firstRow { get; set; } = 0;
        public int firstColumn { get; set; } = 0;
        public int headerRowCount { get; set; } = 1;
        public int maxRow { get; set; } = 5000;
        public ExcelImporterOption()
        {
        }

        public override ICollection<string> GetProperties()
        {
            return GetType().GetProperties().Select(u => u.Name).ToList();
        }

        public override string GetValue()
        {
            var value = JsonConvert.SerializeObject(this);
            return value;
        }

        public override void Load(string value)
        {
            var obj = JsonConvert.DeserializeObject(value, GetType()) as ExcelImporterOption<Element>;
            filePath = obj.filePath;
            firstRow = obj.firstRow;
            headerRowCount = obj.headerRowCount;
            firstColumn = obj.firstColumn;
            maxRow = 5000;
        }
    }
}
