using DMCIT.Core.Entities.Templates;

namespace DMCIT.Core.Entities.Reports.Templates
{
    public class CustomerPaymentMessageTemplate :
        TextTemplate
    {
        public override Template Default()
        {
            var template = base.Default();
            var text = "DOMESCO cam on KH {Customer} da TT {PaymentAmount} VND vao ngay {ReceiptDate}. Du no con lai {ARAmount} VND.";
            template.Value = text;
            return template;
        }
    }
}
