using DMCIT.Core.Entities.Messaging.Settings;
using DMCIT.Core.Entities.Workflow;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DMCIT.Infrastructure.Data.Workflow.WorkflowTasks.MailTask
{
    public class MailsSender : WorkflowTask
    {
        public bool IsBodyHtml { get; set; }
        private readonly SMTPSetting _setting;

        public MailsSender(SMTPSetting setting)
        {
            _setting = setting;
        }


        public MailsSender(int id, DefinedWorkflowTask xe, Workflow wf) : base(id, xe, wf)
        {
            init();
        }

        [ActivatorUtilitiesConstructor]
        public MailsSender(IWorkflowService service, ISettingRepository rep, int id, DefinedWorkflowTask xe, WorkingWorkflow wf) : base(service, id, xe, wf)
        {
            init();
            _setting = rep.GetSettingStore().GetSetting<SMTPSetting>();
        }

        private void init()
        {
            IsBodyHtml = bool.Parse(GetSetting("isBodyHtml", "true"));
        }

        protected override async Task<TaskStatus> _run()
        {
            Info("Sending mails...");
            bool success = true;
            bool atLeastOneSucceed = false;

            try
            {
                FileInf[] attachments = SelectAttachments();

                foreach (FileInf mailFile in SelectFiles())
                {
                    var xdoc = XDocument.Load(mailFile.Path);
                    var xMails = xdoc.XPathSelectElements("Mails/Mail");

                    int count = 1;
                    foreach (XElement xMail in xMails)
                    {
                        Mail mail;
                        try
                        {
                            mail = Mail.Parse(xMail, attachments, Workflow.Parameters);
                        }
                        catch (ThreadAbortException)
                        {
                            throw;
                        }
                        catch (Exception e)
                        {
                            ErrorFormat("An error occured while parsing the mail {0}. Please check the XML configuration according to the documentation. Error: {1}", count, e.Message);
                            success = false;
                            count++;
                            continue;
                        }

                        try
                        {
                            await mail.Send(_setting.Host, _setting.Port, _setting.EnableSsl, _setting.User, _setting.Password, IsBodyHtml);
                            InfoFormat("Mail {0} sent.", count);
                            count++;

                            if (!atLeastOneSucceed) atLeastOneSucceed = true;
                        }
                        catch (ThreadAbortException)
                        {
                            throw;
                        }
                        catch (Exception e)
                        {
                            ErrorFormat("An error occured while sending the mail {0}. Error message: {1}", count, e.Message);
                            success = false;
                        }
                    }
                }
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (Exception e)
            {
                ErrorFormat("An error occured while sending mails.", e);
                success = false;
            }

            var status = Status.Done;

            if (!success && atLeastOneSucceed)
            {
                status = Status.Warning;
            }
            else if (!success)
            {
                status = Status.Failed;
            }

            Info("Task finished.");
            return new TaskStatus(status, false);
        }

        public FileInf[] SelectAttachments()
        {
            var files = new List<FileInf>();
            var setting = GetSetting("selectAttachments");
            if (setting == null)
                return files.ToArray();
            foreach (var task in setting.Value.Split(';'))
            {
                var xTaskId = task;
                if (xTaskId != null)
                {
                    var taskId = int.Parse(task);
                    var qf = QueryFiles(Workflow.FilesPerTask[taskId], setting.Attributes).ToArray();
                    files.AddRange(qf);
                }
                else
                {
                    var qf = (from lf in Workflow.FilesPerTask.Values
                              from f in QueryFiles(lf, setting.Attributes)
                              select f).Distinct().ToArray();
                    files.AddRange(qf);
                }
            }
            return files.ToArray();
        }
    }
}
