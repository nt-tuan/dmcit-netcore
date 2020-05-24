using DMCIT.Core.Entities.Processes;
using DMCIT.Core.Entities.Workflow;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data.Workflow
{
    /// <summary>
    /// Task.
    /// </summary>
    public abstract class WorkflowTask
    {
        //public ILogger Logger { get; set; }
        /// <summary>
        /// Task Id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Task name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Task description.
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Shows whether this task is enabled or not.
        /// </summary>
        public bool IsEnabled { get; private set; }
        /// <summary>
        /// Shows whether this task is waiting for approval.
        /// </summary>
        public bool IsWaitingForApproval { get; set; }
        /// <summary>
        /// Task settings.
        /// </summary>
        public List<Setting> Settings { get; private set; }
        /// <summary>
        /// Workflow.
        /// </summary>
        public WorkingWorkflow Workflow { get; private set; }
        public Workflow Reference { get; private set; }
        /// <summary>
        /// Log messages.
        /// </summary>
        public List<string> Logs { get; private set; }
        /// <summary>
        /// Task files.
        /// </summary>
        /// 
        public BaseProgress Progress { get; set; }
        public List<FileInf> Files
        {
            get
            {
                if (Workflow == null)
                    return new List<FileInf>();
                return Workflow.FilesPerTask[Id];
            }
        }

        public void AddFileConcurrent(FileInf file)
        {
            lock (Workflow)
            {
                Files.Add(file);
            }
        }

        /// <summary>
        /// Task entities.
        /// </summary>
        public List<Entity> Entities
        {
            get
            {
                return Workflow.EntitiesPerTask[Id];
            }
        }
        /// <summary>
        /// Hashtable used as shared memory for tasks.
        /// </summary>
        public Hashtable Hashtable
        {
            get
            {
                return Workflow.Hashtable;
            }
        }

        public readonly IWorkflowService _service;
        public WorkflowTask() { }
        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="xe">XElement.</param>
        /// <param name="wf">Workflow.</param>
		protected WorkflowTask(int id, DefinedWorkflowTask def, Workflow wf)
        {
            Logs = new List<string>();
            Id = id;
            Name = def.Name;
            Description = def.Description;
            IsEnabled = def.IsEnabled;
            IsWaitingForApproval = def.Approval;
            // settings
            IList<Setting> settings = new List<Setting>();
            Reference = wf;
            Settings = def.Settings.Select(u => new Setting(u.Name, u.Value, u.Attributes.Select(v => new Attribute(v.Key, v.Value)))).ToList();
        }

        public WorkflowTask(int id, DefinedWorkflowTask task, WorkingWorkflow wf) : this(id, task, wf.Root)
        {
            Workflow = wf;
            Workflow.FilesPerTask.Add(Id, new List<FileInf>());
            Workflow.EntitiesPerTask.Add(Id, new List<Entity>());
        }

        protected WorkflowTask(IWorkflowService service, int id, DefinedWorkflowTask task, WorkingWorkflow wf) : this(id, task, wf)
        {
            _service = service;
        }
        /// <summary>
        /// Starts the task.
        /// </summary>
        /// <returns>Task status.</returns>
        protected abstract Task<TaskStatus> _run();

        public async Task<TaskStatus> Run()
        {
            lock (Workflow)
            {
                Progress = new BackgroundProgress();
                if (IsWaitingForApproval)
                {
                    WaitForApproval();
                    return new TaskStatus(Status.Pending);
                }
            }
            try
            {
                lock (Workflow)
                {
                    Progress.Id = Id;
                    Progress.SetBegin();
                }
                await _service.OnWorkflowTaskStart(this);
                var rs = await _run();
                lock (Workflow)
                {
                    Progress.SetEnd();
                }
                await _service.OnWorkflowTaskEnd(this);
                return rs;
            }
            catch
            {
                lock (Workflow)
                {
                    Progress.SetError();
                }
                return new TaskStatus(Status.Failed);
            }
        }

        /// <summary>
        /// Returns a setting value from its name.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <returns>Setting value.</returns>
        public Setting GetSetting(string name)
        {
            foreach (var item in Settings)
            {
                if (item.Name == name)
                    return item;
            }
            return null;
        }

        /// <summary>
        /// Returns a setting value from its name and returns a default value if the setting value is not found.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Setting value.</returns>
        public string GetSetting(string name, string defaultValue)
        {
            var returnValue = GetSetting(name);

            if (returnValue == null || string.IsNullOrEmpty(returnValue.Value))
            {
                return defaultValue;
            }

            return returnValue.Value;
        }

        /// <summary>
        /// Returns a setting value from its name and returns a default value if the setting value is not found.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Setting value.</returns>
        public T GetSetting<T>(string name, T defaultValue = default(T))
        {
            var returnValue = GetSetting(name);

            if (string.IsNullOrEmpty(returnValue.Value))
            {
                return defaultValue;
            }

            return (T)Convert.ChangeType(returnValue, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns a setting value from its name and returns a default value if the setting value is not found.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Setting value.</returns>
        public int GetSettingInt(string name, int defaultValue)
        {
            var value = GetSetting(name, defaultValue.ToString());
            return int.Parse(value);
        }

        /// <summary>
        /// Returns a setting value from its name and returns a default value if the setting value is not found.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <param name="defaultValue">Default value.</param>
        /// <returns>Setting value.</returns>
        public bool GetSettingBool(string name, bool defaultValue)
        {
            var value = GetSetting(name, defaultValue.ToString());
            return bool.Parse(value);
        }

        /// <summary>
        /// Returns a list of setting values from a setting name.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <returns>A list of setting values.</returns>
        public string[] GetSettings(string name)
        {
            var s = Settings.Where(u => u.Name == name).Select(u => u.Value);
            return s.ToArray();
        }

        /// <summary>
        /// Returns a list of integers from a setting name.
        /// </summary>
        /// <param name="name">Setting name.</param>
        /// <returns>A list of integers.</returns>
        public int[] GetSettingsInt(string name)
        {
            return GetSettings(name).Select(int.Parse).ToArray();
        }

        /// <summary>
        /// Returns a list of the files loaded by this task through selectFiles setting.
        /// </summary>
        /// <returns>A list of the files loaded by this task through selectFiles setting.</returns>
        public FileInf[] SelectFiles()
        {
            var files = new List<FileInf>();
            var settings = GetSetting("selectFiles");
            if (settings == null)
                return files.ToArray();

            foreach (var selectedFile in settings.Value.Split(';'))
            {
                var xTaskId = selectedFile;
                if (xTaskId != null)
                {
                    var taskId = int.Parse(xTaskId);

                    var qf = QueryFiles(Workflow.FilesPerTask[taskId], settings.Attributes).ToArray();

                    files.AddRange(qf);
                }
                else
                {
                    var qf = (from lf in Workflow.FilesPerTask.Values
                              from f in QueryFiles(lf, settings.Attributes)
                              select f).Distinct().ToArray();

                    files.AddRange(qf);
                }
            }
            return files.ToArray();
        }

        /// <summary>
        /// Filters a list of files from the tags in selectFiles setting.
        /// </summary>
        /// <param name="files">Files to filter.</param>
        /// <param name="xSelectFile">selectFile as an XElement</param>
        /// <returns>A list of files from the tags in selectFiles setting.</returns>
        public IEnumerable<FileInf> QueryFiles(IEnumerable<FileInf> files, IEnumerable<Attribute> atts)
        {
            var fl = new List<FileInf>();

            if (atts == null || atts.Count() == 0)
                return files;

            foreach (var file in files)
            {
                bool ok = true;
                foreach (var a in atts)
                {
                    if (a.Name != "name" && a.Name != "value")
                    {
                        ok &= file.Tags.Any(u => u.Value == a.Value && u.Key == a.Value);
                    }
                }
                if (ok)
                    fl.Add(file);
            }
            return fl;
        }

        /// <summary>
        /// Returns a list of the entities loaded by this task through selectEntities setting.
        /// </summary>
        /// <returns>A list of the entities loaded by this task through selectEntities setting.</returns>
        public Entity[] SelectEntities()
        {
            var entities = new List<Entity>();
            foreach (string id in GetSettings("selectEntities"))
            {
                var taskId = int.Parse(id);
                entities.AddRange(Workflow.EntitiesPerTask[taskId]);
            }
            return entities.ToArray();
        }

        /// <summary>
        /// Returns an object from the Hashtable through selectObject setting.
        /// </summary>
        /// <returns>An object from the Hashtable through selectObject setting.</returns>
        public object SelectObject()
        {
            var key = GetSetting("selectObject");
            if (Hashtable.ContainsKey(key))
            {
                return Hashtable[key];
            }
            return null;
        }

        private string BuildLogMsg(string msg)
        {
            return string.Format("{0} [{1}] {2}", Workflow.LogTag, GetType().Name, msg);
        }

        /// <summary>
        /// Logs an information message.
        /// </summary>
        /// <param name="msg">Log message.</param>
        public void Info(string msg)
        {
            var message = BuildLogMsg(msg);
            lock (Workflow)
            {
                //Logger.LogInformation(message);
                Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  INFO - " + message);
            }
            _service.OnWorkflowTaskChange(this).Wait();
        }

        /// <summary>
        /// Logs a formatted information message.
        /// </summary>
        /// <param name="msg">Formatted log message.</param>
        /// <param name="args">Arguments.</param>
        public void InfoFormat(string msg, params object[] args)
        {
            var message = string.Format(BuildLogMsg(msg), args);
            //Logger.LogInformation(message);
            lock (Workflow)
            {
                Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  INFO - " + message);
            }
            _service.OnWorkflowTaskChange(this).Wait();
        }

        /// <summary>
        /// Logs a Debug log message.
        /// </summary>
        /// <param name="msg">Log message.</param>
        public void Debug(string msg)
        {
            var message = BuildLogMsg(msg);
            //Logger.LogDebug(msg);
            Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  DEBUG - " + message);
            _service.OnWorkflowTaskChange(this).Wait();
        }

        /// <summary>
        /// Logs a formatted debug message.
        /// </summary>
        /// <param name="msg">Log message.</param>
        /// <param name="args">Arguments.</param>
        public void DebugFormat(string msg, params object[] args)
        {
            var message = string.Format(BuildLogMsg(msg), args);
            //Logger.LogDebug(message);
            Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  DEBUG - " + message);
            _service.OnWorkflowTaskChange(this).Wait();
        }

        /// <summary>
        /// Logs an error log message.
        /// </summary>
        /// <param name="msg">Log message.</param>
        public void Error(string msg)
        {
            var message = BuildLogMsg(msg);
            lock (Workflow)
            {
                //Logger.LogError(message);
                Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  ERROR - " + message);
            }
            _service.OnWorkflowTaskChange(this).Wait();
        }

        public void Error(Exception e)
        {
            var mes = e.Message;
            var temp = e;
            while (temp.InnerException != null)
            {
                temp = temp.InnerException;
                mes += Environment.NewLine + temp.Message;
            }
            Error(mes);
        }

        /// <summary>
        /// Logs a formatted error message.
        /// </summary>
        /// <param name="msg">Log message.</param>
        /// <param name="args">Arguments.</param>
        public void ErrorFormat(string msg, params object[] args)
        {
            var message = string.Format(BuildLogMsg(msg), args);
            //Logger.LogError(message);
            Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  ERROR - " + message);
            _service.OnWorkflowTaskChange(this).Wait();
        }

        /// <summary>
        /// Logs an error message and an exception.
        /// </summary>
        /// <param name="msg">Log message.</param>
        /// <param name="e">Exception.</param>
        public void Error(string msg, Exception e)
        {
            var message = BuildLogMsg(msg);
            //Logger.LogError(message, e);
            Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  ERROR - " + message + "\r\n" + e);
            _service.OnWorkflowTaskChange(this).Wait();
        }

        public void WaitForApproval()
        {
            Progress.SetApproval();
            Info("Waiting for approval");
        }

        /// <summary>
        /// Logs a formatted log message and an exception.
        /// </summary>
        /// <param name="msg">Formatted log message.</param>
        /// <param name="e">Exception.</param>
        /// <param name="args">Arguments.</param>
        public void ErrorFormat(string msg, Exception e, params object[] args)
        {
            var message = string.Format(BuildLogMsg(msg), args);
            //Logger.LogError(message, e);
            Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  ERROR - " + message + "\r\n" + e);
            _service.OnWorkflowTaskChange(this).Wait();
        }

        public virtual void Copy(WorkflowTask source, WorkflowTask dest)
        {
            dest.Id = source.Id;
            dest.Name = source.Name;
            dest.Description = source.Description;
            dest.IsEnabled = source.IsEnabled;
            dest.IsWaitingForApproval = source.IsWaitingForApproval;
            dest.Settings = source.Settings;
            dest.Workflow = source.Workflow;
        }
    }
}
