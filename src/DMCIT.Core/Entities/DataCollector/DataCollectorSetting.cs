using DMCIT.Core.Entities.System;
using System;
using System.Data.SqlClient;

namespace DMCIT.Core.Entities.DataCollector
{
    public class DataCollectorSetting : BaseSetting
    {
        public string CollectDiary131Query { get; set; }
        public string CollectDiary131QueryDescription { get; set; }
        public DataCollectorSetting()
        {

        }

        public override void LoadDefault()
        {
            CollectDiary131Query = ("Select " +
"[Ngayct] as ReceiptDate," +
"[SoCT] as ReceiptNo," +
"[TKNO] as DebitAccount," +
"[ChitietNO1] as DetailDebit1," +
"[ChitietNO2] as DetailDebit2," +
"[ChitietNO3] as DetailDebit3," +
"[TKCO] as CreditAccount," +
"[ChitietCO1] as DetailCredit1," +
"[ChitietCO2] as DetailCredit2," +
"[ChitietCO3] as DetailCredit3," +
"[SOTIEN] as MoneyAmount, " +
"[machinhanh] as DistributorCode," +
"[NgayHuy] as DateRemoved, " +
"[Locked], " +
"[SourceId] as Id,[Source] " +
        "From Nhatky131 " +
 "Where machinhanh = @macn and ngayct>=@fromdate " +
    "and ngayct<@todate");

            CollectDiary131QueryDescription = "Params: @fromdate,@macn,@todate";
        }

        public SqlParameter[] GetCollectDiary131SqlParameters(string code, DateTime from, DateTime to)
        {
            return new[] {
                new SqlParameter("@fromdate", from),
                new SqlParameter("@macn", code),
                new SqlParameter("@todate", to)
                };
        }
    }
}
