using DMCIT.Web.ApiModels;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Utility
{
    public class FileHelper
    {
        public static async Task scanExcel(IFormFile file, int minHeader, Func<IRow, IRow, Task> func)
        {
            var sFileExtension = Path.GetExtension(file.FileName);
            if (file.Length > 0)
            {
                ISheet sheet;
                using (var stream = file.OpenReadStream())
                {
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                        sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                    }

                    //Read header
                    IRow headerRow = sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;

                    if (cellCount < minHeader)
                        throw new Exception();

                    //Read cells
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                    {
                        await func.Invoke(headerRow, sheet.GetRow(i));
                    }
                }
            }
        }

        public static Dictionary<string, string> GetDeviceFunctions()
        {
            var dic = new Dictionary<string, string>();
            dic.Add("Create", "Thêm");
            dic.Add("Edit", "Cập nhật");
            dic.Add("Upgrade", "Nâng cấp");
            dic.Add("Replace", "Thay thế");
            dic.Add("Disassembly", "Tháo");
            dic.Add("Allocate", "Phân bổ");
            return dic;
        }

        public static bool IsNullOrEmptyCell(ICell cell)
        {
            return cell == null || cell.CellType == CellType.Blank;
        }

        public static MemoryStream CompressImagesToStream(List<Bitmap> images, List<string> imagesname)
        {
            var rsstream = new MemoryStream();
            using (var archive = new ZipArchive(rsstream, ZipArchiveMode.Create, true))
            {
                for (int i = 0; i < images.Count; i++)
                {
                    using (var outputStream = new MemoryStream())
                    {
                        images[i].Save(outputStream, ImageFormat.Jpeg);
                        outputStream.Seek(0, SeekOrigin.Begin);
                        var entry = archive.CreateEntry(imagesname[i]);
                        using (var os = entry.Open())
                        using (var ws = new StreamWriter(os))
                        {
                            ws.Write(outputStream.ToString().ToCharArray());
                        }
                    }
                }
                rsstream.Seek(0, SeekOrigin.Begin);
            }
            return rsstream;
        }

        public static string BitmapToBase64String(Bitmap bitmap)
        {
            string result;
            using (var ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Jpeg);
                ms.Seek(0, SeekOrigin.Begin);
                result = Convert.ToBase64String(ms.ToArray());
            }
            return result;
        }

        public static MemoryStream ToExcelFile<T>(ICollection<T> data, Type itemtype, Func<System.Reflection.PropertyInfo, T, IRow, int, int> addValue)
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

        public static MemoryStream ToExcelFile<T>(ICollection<T> data, string[] headers, Action<T, ISheet, int> createRow)
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

        public static MemoryStream ToExcelFile<T>(List<T> data, Type itemtype)
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
                    try
                    {
                        var prov = pro.GetValue(item);
                        if (prov == null)
                            newRow.CreateCell(count).SetCellValue("");
                        else if (prov is bool)
                            newRow.CreateCell(count).SetCellValue((bool)prov);
                        else if (prov is string)
                            newRow.CreateCell(count).SetCellValue((string)prov);
                        else if (prov is float)
                            newRow.CreateCell(count).SetCellValue((float)prov);
                        else if ((prov is double) || (prov is Decimal?) || (prov is Decimal))
                            newRow.CreateCell(count).SetCellValue((double)(((Decimal?)prov) ?? 0));
                        else if (prov is DateTime)
                            newRow.CreateCell(count).SetCellValue((DateTime)prov);
                        else if (prov is ICollection<MessageModel>)
                        {
                            newRow.CreateCell(count)
                                .SetCellValue(string.Join(Environment.NewLine,
                                ((ICollection<MessageModel>)prov)
                                .Select(u => $"{u.Key}: {u.Content}. ({u.Type})")));
                        }
                    }
                    catch
                    {
                        newRow.CreateCell(count).SetCellValue("");
                    }
                    count++;
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

        public static IDictionary<string, T> CreateDictionary<T>(string key, T value)
        {
            var dict = new Dictionary<string, T>();
            dict.Add(key, value);
            return dict;
        }
    }
}
