using DMCIT.Core.Entities.Templates;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Providers.Excel
{
    public class ExcelImporter<Element> : IParser<Stream, List<Element>>
        where Element : IExcelImportableObject
    {
        ExcelImporterOption<Element> options;
        public ExcelImporter() { }
        public ExcelImporter(ExcelImporterOption<Element> options)
        {
            this.options = options;
        }

        public void LoadTemplate(Template template, IServiceProvider serviceProvider)
        {
            var value = template.Value;
            options = Activator.CreateInstance(Type.GetType(template.ModelName)) as ExcelImporterOption<Element>;
            options.Load(value);
        }

        public async Task<List<Element>> Parse(Stream stream)
        {
            //if (sFileExtension == ".xls")
            //{
            //    HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
            //    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook 

            //}
            XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
            var sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   

            //Read header
            var headerRows = new IRow[options.headerRowCount];
            for (int i = 0; i < options.headerRowCount; i++)
            {
                var row = sheet.GetRow(i + options.firstRow);
                headerRows[i] = row;
            }

            int cellCount = sheet.GetRow(sheet.FirstRowNum).LastCellNum;
            var rs = new List<Element>();
            //Read cells
            for (int i = (sheet.FirstRowNum + options.headerRowCount); i <= sheet.LastRowNum && i <= options.maxRow + sheet.FirstRowNum; i++) //Read Excel File
            {
                var row = sheet.GetRow(i);
                if (row == null)
                    continue;

                var instance = Activator.CreateInstance<Element>();
                instance.ReadExcelRow(row, 0, headerRows);
                rs.Add(instance);
            }
            return rs;
        }
    }
}
