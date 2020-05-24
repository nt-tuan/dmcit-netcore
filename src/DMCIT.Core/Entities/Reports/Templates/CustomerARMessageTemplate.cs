using DMCIT.Core.Entities.Templates;

namespace DMCIT.Core.Entities.Reports.Templates
{
    public class CustomerARMessageTemplate :
        TextTemplate
    {
        public override Template Default()
        {
            var template = base.Default();
            var text = "DOMESCO xin thong bao: vao cuoi ngay {ReceiptDate}, cong no cua KH {Customer} la {AR} VND";
            template.Value = text;
            return template;
        }
    }
}
