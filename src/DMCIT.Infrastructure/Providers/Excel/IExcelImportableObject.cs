using NPOI.SS.UserModel;

namespace DMCIT.Infrastructure.Providers
{
    public interface IExcelImportableObject
    {
        void ReadExcelRow(IRow row, int index, IRow[] headers);

        void ReadExcelCells(IRow row, int index, IRow[] headers);
    }
}
