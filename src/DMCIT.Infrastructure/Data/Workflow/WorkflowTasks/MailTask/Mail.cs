using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DMCIT.Infrastructure.Data.Workflow.WorkflowTasks.MailTask
{
    public class Mail
    {
        public string From { get; }
        public string[] To { get; }
        public string[] Cc { get; }
        public string[] Bcc { get; }
        public string Subject { get; }
        public string Body { get; }
        public FileInf[] Attachments { get; }

        public static string ReplaceStringByParameters(string value, Dictionary<string, string> parameters)
        {
            var subjectBuilder = new StringBuilder(value);
            if (parameters != null)
            {
                foreach (var p in parameters)
                {
                    subjectBuilder.Replace($"{{{p.Key}}}", p.Value);
                }
            }
            return subjectBuilder.ToString();
        }

        public Mail(string from, string[] to, string[] cc, string[] bcc, string subject, string body, FileInf[] attachments)
        {
            From = from;
            To = to;
            Cc = cc;
            Bcc = bcc;
            Subject = subject;
            Body = body;
            Attachments = attachments;
        }

        public async Task Send(string host, int port, bool enableSsl, string user, string password, bool isBodyHtml)
        {
            var smtp = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = enableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(user, password)
            };

            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress(From);
                foreach (string to in To) msg.To.Add(new MailAddress(to));
                foreach (string cc in Cc) msg.CC.Add(new MailAddress(cc));
                foreach (string bcc in Bcc) msg.Bcc.Add(new MailAddress(bcc));
                msg.Subject = Subject;
                msg.Body = Body;
                msg.IsBodyHtml = isBodyHtml;

                foreach (var attachment in Attachments)
                {
                    // Create  the file attachment for this e-mail message.
                    Attachment data = new Attachment(attachment.Path, MediaTypeNames.Application.Octet);
                    // Add time stamp information for the file.
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = File.GetCreationTime(attachment.Path);
                    disposition.ModificationDate = File.GetLastWriteTime(attachment.Path);
                    disposition.ReadDate = File.GetLastAccessTime(attachment.Path);
                    // Add the file attachment to this e-mail message.
                    msg.Attachments.Add(data);
                }

                await smtp.SendMailAsync(msg);
            }
        }

        public static Mail Parse(XElement xe, FileInf[] attachments, Dictionary<string, string> parameters)
        {
            string from = xe.XPathSelectElement("From").Value;
            var to = xe.XPathSelectElement("To").Value.Split(',');

            string[] cc = { };
            var ccElement = xe.XPathSelectElement("Cc");
            if (ccElement != null) cc = ccElement.Value.Split(',');

            string[] bcc = { };
            var bccElement = xe.XPathSelectElement("Bcc");
            if (bccElement != null) bcc = bccElement.Value.Split(',');

            string subject = xe.XPathSelectElement("Subject").Value;
            subject = ReplaceStringByParameters(subject, parameters);
            string body = xe.XPathSelectElement("Body").Value;
            body = ReplaceStringByParameters(body, parameters);

            return new Mail(from, to, cc, bcc, subject, body, attachments);
        }
    }
}
