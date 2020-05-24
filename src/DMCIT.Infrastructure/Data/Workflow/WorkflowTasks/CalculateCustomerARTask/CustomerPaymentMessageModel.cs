using DMCIT.Core.Entities.Messaging;
using DMCIT.Core.Entities.Messaging.TemplateMessage;
using DMCIT.Infrastructure.Providers;
using NPOI.SS.UserModel;
using System;

namespace DMCIT.Infrastructure.Data.Workflow.WorkflowTasks.CalculateCustomerARTask
{
    public class CustomerPaymentMessageModel : IExcelExportableObject
    {
        public CustomerPaymentMessage Entity { get; set; }
        public DateTime? SentTime { get; set; }
        public CustomerPaymentMessageModel() : base()
        {

        }

        public CustomerPaymentMessageModel(CustomerPaymentMessage entity)
        {
            Entity = entity;
        }

        public void RenderExcelCells(IRow row, int colIndex, string[][] headers)
        {
            var workbook = row.Sheet.Workbook;
            var newDataFormat = workbook.CreateDataFormat();
            var style = workbook.CreateCellStyle();
            style.DataFormat = newDataFormat.GetFormat("dd/mm/yyyy");
            var cell = row.CreateCell(colIndex);
            try
            {
                if (headers == null || headers.Length == 0)
                    return;
                var headerCell = headers[0];
                if (headerCell.Length <= colIndex)
                    return;
                var header = headerCell[colIndex].ToLower();
                switch (header)
                {
                    case "customercode":
                        cell.SetCellValue(Entity.CustomerPayment?.CustomerCode);
                        return;
                    case "customername":
                        cell.SetCellValue(Entity.CustomerPayment?.Customer?.GetDisplayName());
                        return;
                    case "distributorcode":
                        cell.SetCellValue(Entity.CustomerPayment?.DistributorCode);
                        return;
                    case "messagecontent":
                        cell.SetCellValue(Entity.MessageContent);
                        return;
                    case "aramount":
                        cell.SetCellValue((double)Entity.CustomerPayment.ARAmount);
                        return;
                    case "payment":
                        cell.SetCellValue((double)Entity.CustomerPayment.Amount);
                        return;
                    case "messagingprovider":
                        cell.SetCellValue(Entity.ReceiverProvider?.MessageServiceProvider?.Code ?? "");
                        return;
                    case "addressee":
                        cell.SetCellValue(Entity.ReceiverProvider?.ReceiverAddress ?? "");
                        return;
                    case "receiptdate":
                        cell.SetCellValue(Entity.CustomerPayment.ReceiptDate);
                        cell.CellStyle = style;

                        return;
                    case "senttime":
                        if (SentTime == null)
                        {
                            cell.SetCellValue("");
                        }
                        else
                        {
                            cell.SetCellValue(SentTime.Value);
                        }
                        return;
                    case "message":
                        cell.SetCellValue(Entity.CustomerPayment?.SentMessage?.Content);
                        return;
                    case "messageresult":
                        try
                        {
                            var status = (SentMessage.SentMessageStatus)Entity.CustomerPayment?.SentMessage?.Status;
                            cell.SetCellValue(status.ToString());
                        }
                        catch
                        {
                            cell.SetCellValue("-");
                        }
                        return;
                }
            }
            catch (Exception e)
            {
                cell.SetCellValue(e.Message);
            }

        }

        public int RenderExcelRow(IRow row, int index, string[][] headers)
        {
            var headerRow = headers[0];
            while (index < headerRow.Length)
            {
                RenderExcelCells(row, index, headers);
                index++;
            }
            return 1;
        }
    }
}
