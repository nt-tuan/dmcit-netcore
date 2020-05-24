using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Providers;
using NPOI.SS.UserModel;
using System;
using System.Linq;

namespace DMCIT.Web.ApiModels
{
    public class BaseModel<T> : BaseModel
    {
        public BaseModel() { }
        public BaseModel(BaseVersionControlEntity<T> entity)
        {
            if (entity.OriginId == null)
                id = entity.Id;
            else
                id = entity.OriginId.Value;
        }
    }
    public class BaseModel : IExcelImportableObject, IExcelExportableObject
    {
        public int id { get; set; }
        public DateTime? dateEnd { get; set; }
        public BaseModel()
        {

        }

        public virtual void ReadExcelRow(IRow row, int index, IRow[] headers)
        {
            var headerRow = headers[0];
            string preHeaderValue = null;
            while (index < headerRow.LastCellNum)
            {
                try
                {
                    var headerCell = headerRow.GetCell(index);
                    if (string.IsNullOrEmpty(headerCell.StringCellValue))
                    {
                        headerCell.SetCellValue(preHeaderValue);
                    }
                    ReadExcelCells(row, index, headers);
                    preHeaderValue = headerCell.StringCellValue;
                }
                catch { }
                index++;
            }
        }
        public virtual void ReadExcelCells(IRow row, int colIndex, IRow[] headers)
        {
            var headerCell = headers[0].GetCell(colIndex);
            var header = headerCell.StringCellValue.ToLower();

            var properties = GetType().GetProperties();
            foreach (var p in properties)
            {
                var pName = p.Name.ToLower();
                var pType = p.PropertyType;
                if (pName == header)
                {
                    if (typeof(IExcelImportableObject).IsAssignableFrom(pType))
                    {
                        var pValue = p.GetValue(this);
                        if (pValue == null)
                        {
                            p.SetValue(this, Activator.CreateInstance(pType));
                            pValue = p.GetValue(this);
                        }
                        if (headers.Count() <= 1)
                            return;
                        ((IExcelImportableObject)pValue).ReadExcelCells(row, colIndex, headers.Skip(1).ToArray());
                        return;

                    }
                    else if (pType.IsPublic)
                    {
                        var cell = row.GetCell(colIndex);

                        if (pType.IsAssignableFrom(typeof(string)))
                            p.SetValue(this, cell.StringCellValue);
                        else if (pType.IsAssignableFrom(typeof(double)))
                            p.SetValue(this, cell.NumericCellValue);
                        else if (pType.IsAssignableFrom(typeof(DateTime)))
                            p.SetValue(this, cell.DateCellValue);
                        else if (pType.IsAssignableFrom(typeof(bool)))
                            p.SetValue(this, cell.BooleanCellValue);
                        return;
                    }
                }
            }
        }

        public virtual int RenderExcelRow(IRow row, int index, string[][] headers)
        {
            var headerRow = headers[0];
            string preHeaderValue = null;
            while (index < headerRow.Length)
            {
                try
                {
                    var headerCell = headerRow[index];
                    if (string.IsNullOrEmpty(headerCell))
                    {
                        headerCell = (preHeaderValue);
                    }
                    RenderExcelCells(row, index, headers);
                    preHeaderValue = headerCell;
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
                index++;
            }
            return 1;
        }
        public virtual void RenderExcelCells(IRow row, int colIndex, string[][] headers)
        {
            if (headers == null || headers.Length == 0)
                return;
            var headerRow = headers[0];
            if (headerRow == null || headerRow.Length <= colIndex)
                return;
            var headerCell = headerRow[colIndex];
            var header = headerCell.ToLower();
            var properties = GetType().GetProperties();
            foreach (var p in properties)
            {
                var pName = p.Name.ToLower();
                var pType = p.PropertyType;
                if (pName == header)
                {
                    var pV = p.GetValue(this);
                    if (pV == null)
                        return;
                    if (typeof(IExcelExportableObject).IsAssignableFrom(pType))
                    {
                        var pValue = (IExcelExportableObject)pV;
                        if (pValue != null && headers.Count() > 1)
                        {
                            pValue.RenderExcelCells(row, colIndex, headers.Skip(1).ToArray());
                        }
                    }
                    else if (pType.IsPublic)
                    {
                        var pValue = pV;
                        var cell = row.CreateCell(colIndex);
                        if (pType.IsAssignableFrom(typeof(string)))
                            cell.SetCellValue((string)pValue);
                        else if (pType.IsAssignableFrom(typeof(double)))
                            cell.SetCellValue((double)pValue);
                        else if (pType.IsAssignableFrom(typeof(decimal)))
                            cell.SetCellValue((double)(decimal)pValue);
                        else if (pType.IsAssignableFrom(typeof(DateTime)))
                            cell.SetCellValue((DateTime)pValue);
                        else if (pType.IsAssignableFrom(typeof(bool)))
                            cell.SetCellValue((bool)pValue);
                        else
                            cell.SetCellValue(pValue.ToString());
                    }

                    return;
                }
            }
        }

    }
}
