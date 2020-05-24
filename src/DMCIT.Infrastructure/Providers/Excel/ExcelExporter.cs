using DMCIT.Core.Entities.Templates;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Providers.Excel
{
    public class ExcelExporter :
        IParser<IEnumerable<IExcelExportableObject>, MemoryStream>,
        IParser<string, MemoryStream>
    {
        ExcelExporterOption options;
        public ExcelExporter()
        {
        }

        bool isExportableType(Type type)
        {
            if (type.IsPrimitive)
                return true;

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var a = type.GetGenericArguments().FirstOrDefault();
                if (a != null && a.IsPrimitive)
                    return true;
            }

            if (typeof(string).IsAssignableFrom(type))
                return true;
            if (typeof(decimal?).IsAssignableFrom(type))
                return true;
            if (typeof(DateTime?).IsAssignableFrom(type))
                return true;
            return false;
        }

        public void generateHeaders(ISheet sheet, Type type, List<IRow> headers, int rowIndex, ref int colIndex)
        {
            var props = type.GetProperties();
            var row = sheet.CreateRow(rowIndex);
            headers.Add(row);
            foreach (var p in props)
            {
                var cell = row.CreateCell(colIndex);
                if (isExportableType(p.PropertyType))
                {
                    cell.SetCellValue(p.Name);
                    colIndex++;
                }
                else if (typeof(IExcelExportableObject).IsAssignableFrom(p.PropertyType))
                {
                    int preColIndex = colIndex;
                    cell.SetCellValue(p.Name);
                    generateHeaders(sheet, p.PropertyType, headers, rowIndex++, ref colIndex);
                    var mergeRegionNum = sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(rowIndex, rowIndex, preColIndex, colIndex));
                }
                else
                {
                    continue;
                }
            }
        }

        private ISheet generateDefaultOption(IEnumerable<IExcelExportableObject> data)
        {
            var type = data.GetType().GenericTypeArguments.FirstOrDefault();
            //GENERATE DEFAULT TEMPLATE
            options = new DefaultExcelExporterOption(type);
            XSSFWorkbook hssfwb = new XSSFWorkbook(); //This will read 2007 Excel format  
            var sheet = hssfwb.CreateSheet(options.sheetName);

            //create headers
            var headers = new List<IRow>();
            var colIndex = 0;
            generateHeaders(sheet, type, headers, 0, ref colIndex);
            options.headerRowCount = headers.Count;
            return sheet;
        }

        IRow getOrCreate(ISheet sheet, int index)
        {
            var row = sheet.GetRow(index);
            if (row == null)
                row = sheet.CreateRow(index);
            return row;
        }

        private IWorkbook Export(IEnumerable<IExcelExportableObject> data, Action<ExcelExporterOption> setOption = null)
        {
            setOption?.Invoke(options);
            //generateDefaultOption(data);
            ISheet sheet;
            if (options != null && !string.IsNullOrEmpty(options.filePath))
                sheet = LoadWorkbook();
            else
                sheet = generateDefaultOption(data);
            var rowIndex = options.firstRow;
            var headers = new string[options.headerRowCount][];
            //var headers = new IRow[options.headerRowCount];
            for (var i = 0; i < options.headerRowCount; i++)
            {
                var headerRow = sheet.GetRow(rowIndex + i);
                headers[i] = new string[options.firstColumn + headerRow.LastCellNum + 1];
                for (var j = 0; j <= options.firstColumn + headerRow.LastCellNum; j++)
                {
                    try
                    {
                        var headerCell = headerRow.GetCell(j);
                        if (headerCell == null || headerCell.CellType == CellType.Blank)
                        {
                            headers[i][j] = string.Empty;
                            continue;
                        }
                        var headerCellStr = headerCell.StringCellValue;
                        if (options.columnMapper.ContainsKey(headerCellStr))
                        {
                            headers[i][j] = options.columnMapper[headerCellStr];
                        }
                        else
                        {
                            headers[i][j] = headerCellStr;
                        }
                    }
                    catch { }
                }
            }
            rowIndex += options.headerRowCount;

            foreach (var item in data)
            {
                var row = sheet.CreateRow(rowIndex);
                var nRow = item.RenderExcelRow(row, options.firstColumn, headers);
                rowIndex += nRow;
            }
            return sheet.Workbook;
        }

        public ISheet LoadWorkbook()
        {
            string path = options.filePath;
            var sFileExtension = Path.GetExtension(path);
            ISheet sheet;
            using (var stream = new FileStream(path, FileMode.Open))
            {
                if (sFileExtension == ".xls")
                {
                    HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                    hssfwb.SetSheetName(options.sheetIndex, options.sheetName);
                    sheet = hssfwb.GetSheetAt(options.sheetIndex); //get first sheet from workbook  
                }
                else
                {
                    XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                    hssfwb.SetSheetName(options.sheetIndex, options.sheetName);
                    sheet = hssfwb.GetSheetAt(options.sheetIndex); //get first sheet from workbook   
                }
            }
            return sheet;

        }

        public void LoadTemplate(Template template, IServiceProvider serviceProvider)
        {
            options = Activator.CreateInstance(Type.GetType(template.ModelName)) as ExcelExporterOption;
            options.Load(template.Value);
        }

        public TemplateParser GetEntity()
        {
            return new TemplateParser
            {
                ClassName = GetType().FullName,
                Name = GetType().Name
            };
        }

        public async Task<MemoryStream> Parse(IEnumerable<IExcelExportableObject> argumentsModel)
        {
            var wb = Export(argumentsModel);
            var stream = new MemoryStream();
            using (var ms = new MemoryStream())
            {
                wb.Write(ms);
                var bytes = ms.ToArray();
                stream.Write(bytes, 0, bytes.Length);
                //ofs.Write(bytes, 0, bytes.Length);
            }
            return stream;
        }

        public async Task<MemoryStream> Parse(string value)
        {

            var data = JsonConvert.DeserializeObject<List<dynamic>>(value);
            var argData = data.Select(u =>
            {
                var element = options.CreateArgument();
                Copy(u, element);
                return element;
            }).ToList();
            var rs = await Parse(argData);
            return rs;
        }

        public void Copy(dynamic ob1, object des)
        {
            var ps = des.GetType().GetProperties();
            foreach (var dp in ps)
            {
                try
                {
                    var value = ob1[dp.Name];
                    if (value != null)
                    {
                        if (dp.PropertyType.IsPrimitive || dp.PropertyType.IsAssignableFrom(typeof(string)))
                            dp.SetValue(des, (string)value);
                        else
                        {
                            var current = Activator.CreateInstance(dp.PropertyType);
                            Copy(value, current);
                            dp.SetValue(des, current);
                        }
                    }
                }
                catch { }
            }
        }

        public static MemoryStream Export<T>(ICollection<T> data, Type itemtype, Func<System.Reflection.PropertyInfo, T, IRow, int, int> addValue)
        {
            XSSFWorkbook wb = new XSSFWorkbook();

            // Tạo ra 1 sheet
            ISheet sheet = wb.CreateSheet();
            // Bắt đầu ghi lên sheet

            // Tạo row
            var row0 = sheet.CreateRow(0);
            int count = 0;
            foreach (var item in itemtype.GetProperties())
            {
                row0.CreateCell(count).SetCellValue(item.Name);
                count++;
            }

            // bắt đầu duyệt mảng và ghi tiếp tục
            int rowIndex = 1;
            foreach (var item in data)
            {
                // tao row mới
                var newRow = sheet.CreateRow(rowIndex);
                // set giá trị
                count = 0;
                foreach (var pro in itemtype.GetProperties())
                {
                    count = addValue(pro, item, newRow, count);
                }
                // tăng index
                rowIndex++;
            }

            var stream = new MemoryStream();
            using (var ms = new MemoryStream())
            {
                wb.Write(ms);
                var bytes = ms.ToArray();
                stream.Write(bytes, 0, bytes.Length);
                //ofs.Write(bytes, 0, bytes.Length);
            }

            return stream;
        }

        public static MemoryStream Export<T>(ICollection<T> data, string[] headers, Action<T, ISheet, int> createRow)
        {
            XSSFWorkbook wb = new XSSFWorkbook();

            // Tạo ra 1 sheet
            ISheet sheet = wb.CreateSheet();
            // Bắt đầu ghi lên sheet

            // Tạo row
            var row0 = sheet.CreateRow(0);
            int count = 0;
            var itemtype = typeof(T);
            foreach (var item in headers)
            {
                row0.CreateCell(count).SetCellValue(item);
                count++;
            }

            // bắt đầu duyệt mảng và ghi tiếp tục
            int rowIndex = 1;

            foreach (var item in data)
            {
                // tao row mới
                createRow(item, sheet, rowIndex);
                rowIndex++;
            }

            var stream = new MemoryStream();
            using (var ms = new MemoryStream())
            {
                wb.Write(ms);
                var bytes = ms.ToArray();
                stream.Write(bytes, 0, bytes.Length);
                //ofs.Write(bytes, 0, bytes.Length);
            }

            return stream;
        }
    }
}
