using DMCIT.Core.Entities.Workflow;
using DMCIT.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data.Workflow.WorkflowTasks.FilesLoader
{
    public class FilesLoader : WorkflowTask
    {
        public string[] Folders { get; private set; }
        public string[] FlFiles { get; private set; }
        public string RegexPattern { get; private set; }
        public bool Recursive { get; private set; }

        public FilesLoader(int id, DefinedWorkflowTask xe, Workflow wf) : base(id, xe, wf)
        {
            init();
        }

        [ActivatorUtilitiesConstructor]
        public FilesLoader(IWorkflowService service, int id, DefinedWorkflowTask xe, WorkingWorkflow wf) : base(service, id, xe, wf)
        {
            init();
        }

        private void init()
        {
            Folders = GetSettings("folder");
            FlFiles = GetSettings("file");
            RegexPattern = GetSetting("regexPattern", "");
            Recursive = bool.Parse(GetSetting("recursive", "false"));
        }

        protected override async Task<TaskStatus> _run()
        {
            Info("Loading files...");

            bool success = true;

            try
            {
                if (Recursive)
                {
                    foreach (string folder in Folders)
                    {
                        var files = GetFilesRecursive(folder);

                        foreach (var file in files)
                        {
                            if (string.IsNullOrEmpty(RegexPattern) || Regex.IsMatch(file, RegexPattern))
                            {
                                var fi = new FileInf(file, Id);
                                AddFileConcurrent(fi);
                                InfoFormat("File loaded: {0}", file);
                            }
                        }
                    }
                }
                else
                {
                    foreach (string folder in Folders)
                    {
                        foreach (string file in Directory.GetFiles(folder))
                        {
                            if (string.IsNullOrEmpty(RegexPattern) || Regex.IsMatch(file, RegexPattern))
                            {
                                var fi = new FileInf(file, Id);
                                AddFileConcurrent(fi);
                                InfoFormat("File loaded: {0}", file);
                            }
                        }
                    }
                }

                foreach (string file in FlFiles)
                {
                    if (File.Exists(file))
                    {
                        AddFileConcurrent(new FileInf(file, Id));
                        InfoFormat("File loaded: {0}", file);
                    }
                    else
                    {
                        ErrorFormat("File not found: {0}", file);
                        success = false;
                    }
                }
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch (Exception e)
            {
                ErrorFormat("An error occured while loading files.", e);
                success = false;
            }

            var status = Status.Done;

            if (!success)
            {
                status = Status.Failed;
            }

            Info("Task finished.");
            return new TaskStatus(status, false);
        }

        private string[] GetFilesRecursive(string dir)
        {
            return Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
        }
    }
}
