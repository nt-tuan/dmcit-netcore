using DMCIT.Core.SharedKernel;
using System;
using System.Data;

namespace DMCIT.Core.Entities.Accounting
{
    public class Diary131 : BaseEntity
    {
        public new string Id { get; set; }
        public decimal MoneyAmount { get; set; }
        public string DebitAccount { get; set; }
        public string DetailDebit1 { get; set; }
        public string DetailDebit2 { get; set; }
        public string DetailDebit3 { get; set; }

        public string CreditAccount { get; set; }
        public string DetailCredit1 { get; set; }
        public string DetailCredit2 { get; set; }
        public string DetailCredit3 { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string ReceiptNo { get; set; }
        public bool Locked { get; set; }
        public string DistributorCode { get; set; }
        public string CustomerCode { get; set; }
        public bool sentMessage { get; set; }
        public string Source { get; set; }

        public override bool Equals(BaseEntity x, BaseEntity y)
        {
            var dX = x as Diary131;
            var dY = x as Diary131;
            return dX.Id == dY.Id &&
                dX.MoneyAmount == dY.MoneyAmount &&
                dX.ReceiptDate == dY.ReceiptDate &&
                dX.CreditAccount == dY.CreditAccount &&
                dX.DetailCredit1 == dY.DetailCredit1 &&
                dX.DetailCredit2 == dY.DetailCredit2 &&
                dX.DetailCredit3 == dY.DetailCredit3 &&
                dX.DetailDebit1 == dY.DetailDebit1 &&
                dX.DetailDebit2 == dY.DetailDebit2 &&
                dX.DetailDebit3 == dY.DetailDebit3 &&
                dX.Locked == dY.Locked &&
                dX.DateRemoved == dY.DateRemoved &&
                dX.ReceiptNo == dY.ReceiptNo;
        }

        public override bool Equals(object obj)
        {
            var e = obj as Diary131;

            return Id == e.Id &&
                MoneyAmount == e.MoneyAmount &&
                ReceiptDate == e.ReceiptDate &&
                CreditAccount == e.CreditAccount &&
                DetailCredit1 == e.DetailCredit1 &&
                DetailCredit2 == e.DetailCredit2 &&
                DetailCredit3 == e.DetailCredit3 &&
                DetailDebit1 == e.DetailDebit1 &&
                DetailDebit2 == e.DetailDebit2 &&
                DetailDebit3 == e.DetailDebit3 &&
                Locked == e.Locked &&
                DateRemoved == e.DateRemoved &&
                ReceiptNo == e.ReceiptNo;
        }

        public override int GetHashCode(BaseEntity obj)
        {
            var e = obj as Diary131;
            return e.Id.Length;
        }

        public override int GetHashCode()
        {
            return Id.Length;
        }

        public void LoadData(IDataReader r)
        {
            try
            {
                ReceiptDate = (DateTime)r["ReceiptDate"];
            }
            catch
            {

            }
            try
            {
                ReceiptNo = r["ReceiptNo"] as string;
            }
            catch
            {

            }
            try
            {
                DebitAccount = r["DebitAccount"] as string;
            }
            catch
            {

            }
            try
            {
                DetailDebit1 = r["DetailDebit1"] as string;
            }
            catch
            {

            }
            try
            {
                DetailDebit2 = r["DetailDebit2"] as string;
            }
            catch
            {

            }
            try
            {
                DetailDebit3 = r["DetailDebit3"] as string;
            }
            catch
            {

            }
            try
            {
                CreditAccount = r["CreditAccount"] as string;
            }
            catch
            {

            }
            try
            {
                DetailCredit1 = r["DetailCredit1"] as string;
            }
            catch
            {

            }
            try
            {
                DetailCredit2 = r["DetailCredit2"] as string;
            }
            catch
            {

            }
            try
            {
                DetailCredit3 = r["DetailCredit2"] as string;
            }
            catch
            {

            }
            try
            {
                MoneyAmount = (decimal)r["MoneyAmount"];
            }
            catch
            {

            }
            try
            {
                DistributorCode = r["DistributorCode"] as string;
            }
            catch
            {

            }
            try
            {
                DateRemoved = r["DateRemoved"] as DateTime?;
            }
            catch
            {

            }
            try
            {
                Locked = (bool)r["Locked"];
            }
            catch
            {

            }
            try
            {
                Id = r["Id"] as string;
            }
            catch
            {

            }
            try
            {
                Source = r["Source"] as string;
            }
            catch
            {

            }
            try
            {
                string credit = null;
                if (CreditAccount.Length > 2)
                    credit = CreditAccount.Substring(0, 3);
                string debit = null;
                if (DebitAccount.Length > 2)
                    debit = DebitAccount.Substring(0, 3);
                if (credit == "131" && DetailCredit1.Length > 3)
                    CustomerCode = DetailCredit1.Substring(2);
                else if (debit == "131" && DetailDebit1.Length > 3)
                    CustomerCode = DetailDebit1.Substring(2);
                CustomerCode = CustomerCode?.ToUpper();
            }
            catch
            {

            }
        }
    }
}
