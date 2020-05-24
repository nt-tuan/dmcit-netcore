using DMCIT.Core.Entities.Messaging;
using DMCIT.Web.ApiModels.HR;
using DMCIT.Web.ApiModels.Sales;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DMCIT.Web.ApiModels.Messaging
{
    public class MessageReceiverModel : BaseModel<MessageReceiver>
    {
        public string displayname { get; set; }
        public string fullname { get; set; }
        public CustomerModel customer { get; set; }
        public int? customerId { get; set; }
        public EmployeeModel employee { get; set; }
        public int? employeeId { get; set; }
        public ICollection<ReceiverProviderModel> providers { get; set; }
        public MessageReceiverModel()
        {

        }
        public MessageReceiverModel(MessageReceiver entity) : base(entity)
        {
            displayname = entity.ShortName;
            fullname = entity.FullName;
            if (entity.Customer != null)
                customer = new CustomerModel(entity.Customer);
            if (entity.Employee != null)
                employee = new EmployeeModel(entity.Employee);
            customerId = entity.CustomerId;
            employeeId = entity.EmployeeId;
            if (entity.ReceiverProviders != null)
            {
                providers = new List<ReceiverProviderModel>();
                foreach (var item in entity.ReceiverProviders)
                {
                    providers.Add(new ReceiverProviderModel(item));
                }
            }
        }
        public MessageReceiver ToEntity()
        {
            var rp = new List<ReceiverProvider>();
            if (providers != null)
            {
                foreach (var item in providers)
                {
                    var rpe = new ReceiverProvider
                    {
                        MessageServiceProviderId = item.provider.id,
                        MessageServiceProvider = item.provider.ToEntity(),
                        ReceiverAddress = item.receiverAddress
                    };
                    rp.Add(rpe);
                }
            }
            var e = new MessageReceiver
            {
                FullName = fullname,
                ShortName = displayname,
                CustomerId = customer?.id,
                EmployeeId = employee != null ? (int?)employee.id : null,
                ReceiverProviders = rp,
                DateEnd = dateEnd
            };
            if (customer != null)
                e.Customer = customer.ToEntity();
            if (employee != null)
                e.Employee = employee.ToEmployee();

            return e;
        }

        public override int RenderExcelRow(IRow row, int index, string[][] headers)
        {
            var headerRow = headers[0];
            string preHeaderValue = null;
            var pI = 0;
            var rootIndex = index;
            do
            {
                index = rootIndex;
                while (index < headerRow.Length)
                {
                    try
                    {
                        var headerCell = headerRow[index];
                        if (string.IsNullOrEmpty(headerCell))
                        {
                            headerCell = (preHeaderValue);
                        }
                        var headerValue = headerCell;
                        if (headerValue == nameof(providers) && providers != null)
                        {
                            var subHeader = headers[1][index];
                            if (subHeader == "provider")
                            {
                                var cell = row.CreateCell(index);
                                if (providers != null)
                                    cell.SetCellValue(providers.ElementAt(pI).provider?.code);
                            }
                            else if (subHeader == "address")
                            {
                                var cell = row.CreateCell(index);
                                if (providers != null)
                                    cell.SetCellValue(providers.ElementAt(pI).receiverAddress);
                            }
                        }
                        else
                        {
                            RenderExcelCells(row, index, headers);
                        }

                        preHeaderValue = headerCell;
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                    index++;
                }
                pI++;
                row = row.Sheet.CreateRow(row.RowNum + 1);
            } while (providers != null && pI < providers.Count);
            return pI;
        }
    }
}
