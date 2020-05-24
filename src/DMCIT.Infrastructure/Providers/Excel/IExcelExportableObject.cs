using NPOI.SS.UserModel;

namespace DMCIT.Infrastructure.Providers
{
    public interface IExcelExportableObject
    {
        //IDictionary<string, Action<T, ICell>> GetHeaders();
        int RenderExcelRow(IRow row, int index, string[][] headers);

        void RenderExcelCells(IRow row, int colIndex, string[][] headers);
    }
}
