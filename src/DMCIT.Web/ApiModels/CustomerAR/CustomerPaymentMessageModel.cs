using DMCIT.Core.Entities.Messaging.TemplateMessage;
using NPOI.SS.UserModel;
using System;

namespace DMCIT.Web.ApiModels.CustomerAR
{
    public class CustomerPaymentMessageModel : CustomerARMessageModel
    {
        public CustomerPaymentModel customerPayment { get; set; }
        public string messageContent { get; set; }
        public CustomerPaymentMessageModel() : base()
        {

        }

        public CustomerPaymentMessageModel(CustomerPaymentMessage entity)
        {
            customerPayment = new CustomerPaymentModel(entity.CustomerPayment);
            messageContent = entity.MessageContent;
            if (entity.ReceiverProvider != null)
                receiverProvider = new Messaging.ReceiverProviderModel(entity.ReceiverProvider);
        }

        public override void RenderExcelCells(IRow row, int colIndex, string[][] headers)
        {
            var cell = row.CreateCell(colIndex);
            try
            {
                if (headers == null || headers.Length == 0 || headers[0] == null || headers[0].Length <= colIndex)
                    return;
                var headerCell = headers[0][colIndex];
                if (headerCell == null)
                    return;
                var header = headerCell.ToLower();
                switch (header)
                {
                    case "customercode":
                        cell.SetCellValue(customerPayment.customerCode);
                        return;
                    case "customername":
                        cell.SetCellValue(customerPayment.customerName);
                        return;
                    case "distributor":
                        cell.SetCellValue(customerPayment.distributorCode);
                        return;
                    case "messagecontent":
                        cell.SetCellValue(messageContent);
                        return;
                    case "aramount":
                        cell.SetCellValue((double)customerPayment.arAmount);
                        return;
                    case "payment":
                        cell.SetCellValue((double)customerPayment.amount);
                        return;
                    case "messagingprovider":
                        if (receiverProvider != null && receiverProvider.provider != null)
                            cell.SetCellValue(receiverProvider.provider.code);
                        else
                            cell.SetCellType(CellType.Blank);
                        return;
                    case "addressee":
                        if (receiverProvider != null)
                            cell.SetCellValue(receiverProvider.receiverAddress);
                        else
                            cell.SetCellType(CellType.Blank);
                        return;
                    case "receiptdate":
                        cell.SetCellValue(customerPayment.createdDate.Value);
                        return;
                }
            }
            catch (Exception e)
            {
                cell.SetCellValue(e.Message);
            }

        }

        public override int RenderExcelRow(IRow row, int index, string[][] headers)
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
