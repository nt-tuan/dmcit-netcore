using DMCIT.Core.Entities.Templates;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DMCIT.Infrastructure.Providers.Excel
{
    public abstract class ExcelExporterOption : SystemTemplate<ExcelExporter, IEnumerable<IExcelExportableObject>, MemoryStream>
    {
        public string filePath { get; set; }
        public int firstRow { get; set; } = 0;
        public int headerRowCount { get; set; } = 1;
        public int sheetIndex { get; set; } = 0;
        public string sheetName { get; set; } = "Data";
        public int firstColumn { get; set; } = 0;
        public Dictionary<string, string> columnMapper { get; set; } = new Dictionary<string, string>();

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
            try
            {
                var obj = JsonConvert.DeserializeObject(value, GetType()) as ExcelExporterOption;
                filePath = obj.filePath;
                firstRow = obj.firstRow;
                headerRowCount = obj.headerRowCount;
                sheetIndex = obj.sheetIndex;
                sheetName = obj.sheetName;
                firstColumn = obj.firstColumn;
                columnMapper = obj.columnMapper;
            }
            catch
            {
                Default();
            }
        }

        public abstract IExcelExportableObject CreateArgument();
    }

    public class ExcelExporterOption<T> : ExcelExporterOption where T : IExcelExportableObject
    {
        public override IExcelExportableObject CreateArgument()
        {
            return (IExcelExportableObject)Activator.CreateInstance(typeof(T));
        }
    }

    public class DefaultExcelExporterOption : ExcelExporterOption
    {
        Type elementType;
        public DefaultExcelExporterOption(Type elementType)
        {
            this.elementType = elementType;
        }
        public override IExcelExportableObject CreateArgument()
        {
            return (IExcelExportableObject)Activator.CreateInstance(elementType);
        }
    }
}
