using Autofac;
using DMCIT.Core.Entities;
using DMCIT.Core.Entities.Workflow;
using DMCIT.Core.Interfaces;
using DMCIT.Infrastructure.Data.Workflow.ExecutionGraph;
using DMCIT.Infrastructure.Data.Workflow.ExecutionGraph.Flowchart;
using DMCIT.Infrastructure.Services;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data.Workflow
{
    public class WorkingWorkflow
    {
        public static int StartId = -1;
        public int _currentTaskId = 0;
        public Guid InstanceId { get; set; }
        public string JobId { get; set; }
        public string LogTag
        {
            get { return string.Format("[{0} / {1}]", Root.Name, JobId); }
        }
        public Variable[] GlobalVariables { get; set; }
        public Variable[] LocalVariables { get; set; }
        public Hashtable Hashtable { get; private set; }
        private readonly IWorkflowRepository _rep;
        private readonly IWorkflowService _service;
        private ILogger Logger;
        private HistoryWorkflowEntry _historyEntry;
        private GeneralSetting _generalSetting;
        private WorkflowSetting _setting;
        public Workflow Root { get; }
        /// <summary>
        /// Shows whether this workflow is waiting for approval.
        /// </summary>
        public bool IsWaitingForApproval { get; set; }
        /// <summary>
        /// Shows whether this workflow is disapproved or not.
        /// </summary>
        public bool IsDisapproved { get; private set; }
        /// <summary>
        /// Shows whether this workflow is running or not.
        /// </summary>
        public bool IsRunning { get; private set; }
        /// <summary>
        /// Shows whether this workflow is suspended or not.
        /// </summary>
        public bool IsPaused { get; private set; }
        public Dictionary<string, string> Parameters { get; set; }
        private bool _stopCalled;
        private WorkflowRunResult _result;
        /// <summary>
        /// Log messages.
        /// </summary>
        public List<string> Logs { get; private set; }
        /// <summary>
        /// Workflow tasks.
        /// </summary>
        public WorkflowTask[] Tasks { get; private set; }
        /// <summary>
        /// Workflow files.
        /// </summary>
        public Dictionary<int, List<FileInf>> FilesPerTask { get; private set; }
        /// <summary>
        /// Workflow entities.
        /// </summary>
        public Dictionary<int, List<Entity>> EntitiesPerTask { get; private set; }
        /// <summary>
        /// Rest variables.
        /// </summary>
        public List<Variable> RestVariables { get; private set; }

        [ActivatorUtilitiesConstructor]
        public WorkingWorkflow(ILogger<IWorkflowService> logger, IServiceProvider sp, IWorkflowService service, IWorkflowRepository rep, ISettingRepository settingRep, WorkingWorkflow ready)
        {
            Logger = logger;
            _rep = rep;
            _service = service;
            var settingStored = settingRep.GetSettingStore();
            _generalSetting = settingStored.GetSetting<GeneralSetting>();
            _setting = settingStored.GetSetting<WorkflowSetting>();
            Root = ready.Root;
            Parameters = ready.Parameters;
            Logs = new List<string>();
            //
            // Parse the workflow file (Global variables and local variables.)
            //
            Hashtable = new Hashtable();
            GlobalVariables = ready.Root.GlobalVariables;
            FilesPerTask = new Dictionary<int, List<FileInf>>();
            EntitiesPerTask = new Dictionary<int, List<Entity>>();
            RestVariables = new List<Variable>();
            InstanceId = ready.InstanceId;
        }

        public WorkingWorkflow(Workflow root, Dictionary<string, string> parameters)
        {
            Root = root;
            Parameters = parameters;
            InstanceId = Guid.NewGuid();
        }

        public void LoadTasks(IServiceProvider sp)
        {
            var tasks = new List<WorkflowTask>();
            var infAssembly = Assembly.GetAssembly(typeof(EfRepository));
            var webAssembly = Assembly.GetCallingAssembly();
            //var coreAssembly = Assembly.GetAssembly(typeof(BaseEntity));
            var allTypes = new List<Type>();
            allTypes.AddRange(webAssembly.GetTypes());
            allTypes.AddRange(infAssembly.GetTypes());
            //allTypes.AddRange(coreAssembly.GetTypes());
            var allTasks = allTypes.Where(u => typeof(WorkflowTask).IsAssignableFrom(u));

            var myTasks = JsonConvert.DeserializeObject<Dictionary<int, DefinedWorkflowTask>>(Root.DbEntity.TasksJSON);

            foreach (var item in myTasks)
            {
                var taskDef = item.Value;
                var name = taskDef.Name;
                Type type = allTasks.Where(u => u.Name == name).FirstOrDefault();

                if (type != null)
                {
                    var builder = new ContainerBuilder();
                    try
                    {
                        var task = (WorkflowTask)ActivatorUtilities.CreateInstance(sp, type, item.Key, taskDef, this);
                        tasks.Add(task);
                    }
                    catch
                    {
                        throw new Exception("The type of the task " + name + " could not be loaded.");
                    }

                }
                else
                {
                    throw new Exception("The type of the task " + name + " could not be loaded.");
                }
            }
            Tasks = tasks.ToArray();
        }
        private void LogWorkflowFinished()
        {
            var msg = string.Format("{0} Workflow finished.", LogTag);
            Logger.LogInformation(msg);
            Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.GetCultureInfo(_generalSetting.CultureInfo)) + " INFO  - " + msg);
        }
        private WorkflowTask[] NodesToTasks(Node[] nodes)
        {
            var tasks = new List<WorkflowTask>();

            if (nodes == null) return tasks.ToArray();

            foreach (var node in nodes)
            {
                var @if = node as If;
                if (@if != null)
                {
                    var doTasks = NodesToTasks(@if.DoNodes);
                    var otherwiseTasks = NodesToTasks(@if.ElseNodes);

                    var ifTasks = new List<WorkflowTask>(doTasks);
                    foreach (var task in otherwiseTasks)
                    {
                        if (ifTasks.All(t => t.Id != task.Id))
                        {
                            ifTasks.Add(task);
                        }
                    }

                    tasks.AddRange(ifTasks);
                }
                else if (node is While)
                {
                    tasks.AddRange(NodesToTasks(((While)node).Nodes));
                }
                else if (node is Switch)
                {
                    var @switch = (Switch)node;
                    tasks.AddRange(NodesToTasks(@switch.Default).Where(task => tasks.All(t => t.Id != task.Id)));
                    tasks.AddRange(NodesToTasks(@switch.Cases.SelectMany(@case => @case.Nodes).ToArray()).Where(task => tasks.All(t => t.Id != task.Id)));
                }
                else
                {
                    var task = GetTask(node.Id);

                    if (task != null)
                    {
                        if (tasks.All(t => t.Id != task.Id))
                        {
                            tasks.Add(task);
                        }
                    }
                    else
                    {
                        throw new Exception("Task " + node.Id + " not found.");
                    }
                }
            }

            return tasks.ToArray();
        }
        private Status RunTasks(Node[] nodes, WorkflowTask[] tasks, bool force)
        {
            var success = true;
            var warning = false;
            var atLeastOneSucceed = false;

            if (nodes.Any())
            {
                var startNode = GetStartupNode(nodes);

                var @if = startNode as If;
                if (@if != null)
                {
                    var doIf = @if;
                    RunIf(tasks, nodes, doIf, force, ref success, ref warning, ref atLeastOneSucceed);
                }
                else if (startNode is While)
                {
                    var doWhile = (While)startNode;
                    RunWhile(tasks, nodes, doWhile, force, ref success, ref warning, ref atLeastOneSucceed);
                }
                else
                {
                    if (startNode.ParentId == StartId)
                    {
                        RunTasks(tasks, nodes, startNode, force, ref success, ref warning, ref atLeastOneSucceed);
                    }
                }
            }

            if (IsDisapproved)
            {
                return Status.Disapproved;
            }

            if (success)
            {
                return Status.Done;
            }

            if (atLeastOneSucceed || warning)
            {
                return Status.Warning;
            }

            return Status.Failed;
        }
        private void updateStatus(TaskStatus status)
        {
            lock (this)
            {
                _result.success &= status.Status == Status.Done;
                _result.warning |= status.Status == Status.Warning;
                _result.error &= status.Status == Status.Failed;
            }
        }

        private async Task RunSequentialTasks()
        {
            var atLeastOneSucceed = false;
            if (Tasks == null || Tasks.Count() == 0)
            {
                throw new Exception("No tasks found");
            }
            while (_currentTaskId < Tasks.Count())
            {
                var i = _currentTaskId;
                lock (this)
                {
                    _currentTaskId++;
                }
                var task = Tasks[i];
                if (!task.IsEnabled) continue;
                if (Root.IsApproval && IsDisapproved) break;
                var status = await task.Run();
                if (task.IsWaitingForApproval)
                {
                    lock (this)
                    {
                        IsWaitingForApproval = true;
                        _currentTaskId--;
                    }
                    break;
                }
                Logs.AddRange(task.Logs);
                updateStatus(status);
                if (!atLeastOneSucceed && status.Status == Status.Done)
                    atLeastOneSucceed = true;
                if (Root.StopWhenError && _result.error)
                {
                    break;
                }
            }

            if (Tasks.Count() > 0 && !_result.success && atLeastOneSucceed)
            {
                lock (this)
                {
                    _result.warning = true;
                }
            }
        }

        private void RunTasks(WorkflowTask[] tasks, Node[] nodes, Node node, bool force, ref bool success, ref bool warning, ref bool atLeastOneSucceed)
        {
            if (node != null)
            {
                if (node is If || node is While || node is Switch)
                {
                    var if1 = node as If;
                    if (if1 != null)
                    {
                        var @if = if1;
                        RunIf(tasks, nodes, @if, force, ref success, ref warning, ref atLeastOneSucceed);
                    }
                    else if (node is While)
                    {
                        var @while = (While)node;
                        RunWhile(tasks, nodes, @while, force, ref success, ref warning, ref atLeastOneSucceed);
                    }
                    else
                    {
                        var @switch = (Switch)node;
                        RunSwitch(tasks, nodes, @switch, force, ref success, ref warning, ref atLeastOneSucceed);
                    }
                }
                else
                {
                    var task = GetTask(tasks, node.Id);
                    if (task != null)
                    {
                        if (task.IsEnabled && ((!Root.IsApproval || (Root.IsApproval && !IsDisapproved)) || force))
                        {
                            var status = task.Run().Result;
                            Logs.AddRange(task.Logs);

                            success &= status.Status == Status.Done;
                            warning |= status.Status == Status.Warning;
                            if (!atLeastOneSucceed && status.Status == Status.Done) atLeastOneSucceed = true;

                            var childNode = nodes.FirstOrDefault(n => n.ParentId == node.Id);

                            if (childNode != null)
                            {
                                var if1 = childNode as If;
                                if (if1 != null)
                                {
                                    var @if = if1;
                                    RunIf(tasks, nodes, @if, force, ref success, ref warning, ref atLeastOneSucceed);
                                }
                                else if (childNode is While)
                                {
                                    var @while = (While)childNode;
                                    RunWhile(tasks, nodes, @while, force, ref success, ref warning, ref atLeastOneSucceed);
                                }
                                else if (childNode is Switch)
                                {
                                    var @switch = (Switch)childNode;
                                    RunSwitch(tasks, nodes, @switch, force, ref success, ref warning, ref atLeastOneSucceed);
                                }
                                else
                                {
                                    var childTask = GetTask(tasks, childNode.Id);
                                    if (childTask != null)
                                    {
                                        if (childTask.IsEnabled && ((!Root.IsApproval || (Root.IsApproval && !IsDisapproved)) || force))
                                        {
                                            var childStatus = childTask.Run().Result;
                                            Logs.AddRange(childTask.Logs);

                                            success &= childStatus.Status == Status.Done;
                                            warning |= childStatus.Status == Status.Warning;
                                            if (!atLeastOneSucceed && status.Status == Status.Done) atLeastOneSucceed = true;

                                            // Recusive call
                                            var ccNode = nodes.FirstOrDefault(n => n.ParentId == childNode.Id);

                                            var node1 = ccNode as If;
                                            if (node1 != null)
                                            {
                                                var @if = node1;
                                                RunIf(tasks, nodes, @if, force, ref success, ref warning, ref atLeastOneSucceed);
                                            }
                                            else if (ccNode is While)
                                            {
                                                var @while = (While)ccNode;
                                                RunWhile(tasks, nodes, @while, force, ref success, ref warning, ref atLeastOneSucceed);
                                            }
                                            else if (ccNode is Switch)
                                            {
                                                var @switch = (Switch)ccNode;
                                                RunSwitch(tasks, nodes, @switch, force, ref success, ref warning, ref atLeastOneSucceed);
                                            }
                                            else
                                            {
                                                RunTasks(tasks, nodes, ccNode, force, ref success, ref warning, ref atLeastOneSucceed);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Task " + childNode.Id + " not found.");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Task " + node.Id + " not found.");
                    }
                }
            }
        }

        private void RunIf(WorkflowTask[] tasks, Node[] nodes, If @if, bool force, ref bool success, ref bool warning, ref bool atLeastOneSucceed)
        {
            var ifTask = GetTask(@if.IfId);

            if (ifTask != null)
            {
                if (ifTask.IsEnabled && (!Root.IsApproval || (Root.IsApproval && !IsDisapproved)))
                {
                    var status = ifTask.Run().Result;
                    Logs.AddRange(ifTask.Logs);

                    success &= status.Status == Status.Done;
                    warning |= status.Status == Status.Warning;
                    if (!atLeastOneSucceed && status.Status == Status.Done) atLeastOneSucceed = true;

                    if (status.Status == Status.Done && status.Condition)
                    {
                        if (@if.DoNodes.Length > 0)
                        {
                            // Build Tasks
                            var doIfTasks = NodesToTasks(@if.DoNodes);

                            // Run Tasks
                            var doIfStartNode = GetStartupNode(@if.DoNodes);

                            if (doIfStartNode.ParentId == StartId)
                            {
                                RunTasks(doIfTasks, @if.DoNodes, doIfStartNode, force, ref success, ref warning, ref atLeastOneSucceed);
                            }
                        }
                    }
                    else if (status.Condition == false)
                    {
                        if (@if.ElseNodes.Length > 0)
                        {
                            // Build Tasks
                            var elseTasks = NodesToTasks(@if.ElseNodes);

                            // Run Tasks
                            var elseStartNode = GetStartupNode(@if.ElseNodes);

                            RunTasks(elseTasks, @if.ElseNodes, elseStartNode, force, ref success, ref warning, ref atLeastOneSucceed);
                        }
                    }

                    // Child node
                    var childNode = nodes.FirstOrDefault(n => n.ParentId == @if.Id);

                    if (childNode != null)
                    {
                        RunTasks(tasks, nodes, childNode, force, ref success, ref warning, ref atLeastOneSucceed);
                    }
                }
            }
            else
            {
                throw new Exception("Task " + @if.Id + " not found.");
            }
        }

        private void RunWhile(WorkflowTask[] tasks, Node[] nodes, While @while, bool force, ref bool success, ref bool warning, ref bool atLeastOneSucceed)
        {
            var whileTask = GetTask(@while.WhileId);

            if (whileTask != null)
            {
                if (whileTask.IsEnabled && (!Root.IsApproval || (Root.IsApproval && !IsDisapproved)))
                {
                    while (true)
                    {
                        var status = whileTask.Run().Result;
                        Logs.AddRange(whileTask.Logs);

                        success &= status.Status == Status.Done;
                        warning |= status.Status == Status.Warning;
                        if (!atLeastOneSucceed && status.Status == Status.Done) atLeastOneSucceed = true;

                        if (status.Status == Status.Done && status.Condition)
                        {
                            if (@while.Nodes.Length > 0)
                            {
                                // Build Tasks
                                var doWhileTasks = NodesToTasks(@while.Nodes);

                                // Run Tasks
                                var doWhileStartNode = GetStartupNode(@while.Nodes);

                                RunTasks(doWhileTasks, @while.Nodes, doWhileStartNode, force, ref success, ref warning, ref atLeastOneSucceed);
                            }
                        }
                        else if (status.Condition == false)
                        {
                            break;
                        }
                    }

                    // Child node
                    var childNode = nodes.FirstOrDefault(n => n.ParentId == @while.Id);

                    if (childNode != null)
                    {
                        RunTasks(tasks, nodes, childNode, force, ref success, ref warning, ref atLeastOneSucceed);
                    }
                }
            }
            else
            {
                throw new Exception("Task " + @while.Id + " not found.");
            }
        }

        private void RunSwitch(WorkflowTask[] tasks, Node[] nodes, Switch @switch, bool force, ref bool success, ref bool warning, ref bool atLeastOneSucceed)
        {
            var switchTask = GetTask(@switch.SwitchId);

            if (switchTask != null)
            {
                if (switchTask.IsEnabled && (!Root.IsApproval || (Root.IsApproval && !IsDisapproved)))
                {
                    var status = switchTask.Run().Result;
                    Logs.AddRange(switchTask.Logs);

                    success &= status.Status == Status.Done;
                    warning |= status.Status == Status.Warning;
                    if (!atLeastOneSucceed && status.Status == Status.Done) atLeastOneSucceed = true;

                    if (status.Status == Status.Done)
                    {
                        bool aCaseHasBeenExecuted = false;
                        foreach (var @case in @switch.Cases)
                        {
                            if (@case.Value == status.SwitchValue)
                            {
                                if (@case.Nodes.Length > 0)
                                {
                                    // Build Tasks
                                    var switchTasks = NodesToTasks(@case.Nodes);

                                    // Run Tasks
                                    var switchStartNode = GetStartupNode(@case.Nodes);

                                    RunTasks(switchTasks, @case.Nodes, switchStartNode, force, ref success, ref warning, ref atLeastOneSucceed);
                                }
                                aCaseHasBeenExecuted = true;
                                break;
                            }
                        }

                        if (!aCaseHasBeenExecuted && @switch.Default != null && @switch.Default.Any())
                        {
                            // Build Tasks
                            var defalutTasks = NodesToTasks(@switch.Default);

                            // Run Tasks
                            var defaultStartNode = GetStartupNode(@switch.Default);

                            RunTasks(defalutTasks, @switch.Default, defaultStartNode, force, ref success, ref warning, ref atLeastOneSucceed);
                        }

                        // Child node
                        var childNode = nodes.FirstOrDefault(n => n.ParentId == @switch.Id);

                        if (childNode != null)
                        {
                            RunTasks(tasks, nodes, childNode, force, ref success, ref warning, ref atLeastOneSucceed);
                        }
                    }
                }
            }
        }
        private void prepareToStart()
        {
            _historyEntry = new HistoryWorkflowEntry(Root.DbEntity);

            _stopCalled = false;
            IsRunning = true;
            IsDisapproved = false;
            var msg = string.Format("{0} Workflow started.", LogTag);
            Logger.LogInformation(msg);
            Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  INFO - " + msg);
            // Create the temp folder
            CreateTempFolder();
            // Run the tasks
            _result = new WorkflowRunResult
            {
                success = true,
                warning = false,
                error = true
            };
        }
        private void cleanUp()
        {
            lock (this)
            {
                if (!_stopCalled)
                {
                    Logs.Clear();
                }

                if (!IsWaitingForApproval)
                {
                    foreach (List<FileInf> files in FilesPerTask.Values) files.Clear();
                    foreach (List<Entity> entities in EntitiesPerTask.Values) entities.Clear();
                    IsRunning = false;
                    IsDisapproved = false;
                    GC.Collect();
                    RestVariables.Clear();
                    _ = Root.Jobs.TryRemove(InstanceId, out _);
                    _service.OnWorkflowEnd(this).Wait();
                }
            }
        }
        private void logResult()
        {
            lock (this)
            {
                if (IsDisapproved)
                {
                    LogWorkflowFinished();
                    _rep.IncrementDisapprovedCount().Wait();
                    _historyEntry.Status = Status.Disapproved;
                }
                if (_result.success)
                {
                    LogWorkflowFinished();
                    _rep.IncrementDoneCount().Wait();
                    _historyEntry.Status = Status.Done;

                }
                else if (_result.warning)
                {
                    LogWorkflowFinished();
                    _rep.IncrementWarningCount().Wait();
                    _historyEntry.Status = Status.Warning;
                }
                else if (_result.error)
                {
                    LogWorkflowFinished();
                    _rep.IncrementFailedCount().Wait();
                    _historyEntry.Status = Status.Failed;
                }
            }
        }
        public async Task Start()
        {
            //var entry = await _rep.GetEntry(Root.Id);            
            try
            {
                await _service.OnWorkflowStart(this);
                prepareToStart();
                if (Root.ExecutionGraph == null)
                {
                    await RunSequentialTasks();
                    if (IsWaitingForApproval)
                    {
                        //LogworkflowWaitForApproval
                        await _rep.IncrementPendingCount();
                        _historyEntry.Status = Status.Pending;
                    }
                    else
                    {
                        logResult();
                    }
                }
                else
                {
                    #region i have not cared about execution yet
                    var status = RunTasks(Root.ExecutionGraph.Nodes, Tasks, false);

                    switch (status)
                    {
                        case Status.Done:
                            if (Root.ExecutionGraph.OnSuccess != null)
                            {
                                var successTasks = NodesToTasks(Root.ExecutionGraph.OnSuccess.Nodes);
                                RunTasks(Root.ExecutionGraph.OnSuccess.Nodes, successTasks, false);
                            }
                            LogWorkflowFinished();
                            await _rep.IncrementDoneCount();
                            _historyEntry.Status = Status.Done;
                            break;
                        case Status.Warning:
                            if (Root.ExecutionGraph.OnWarning != null)
                            {
                                var warningTasks = NodesToTasks(Root.ExecutionGraph.OnWarning.Nodes);
                                RunTasks(Root.ExecutionGraph.OnWarning.Nodes, warningTasks, false);
                            }
                            LogWorkflowFinished();
                            await _rep.IncrementWarningCount();
                            _historyEntry.Status = Status.Warning;
                            break;
                        case Status.Failed:
                            if (Root.ExecutionGraph.OnError != null)
                            {
                                var errorTasks = NodesToTasks(Root.ExecutionGraph.OnError.Nodes);
                                RunTasks(Root.ExecutionGraph.OnError.Nodes, errorTasks, false);
                            }
                            LogWorkflowFinished();
                            await _rep.IncrementFailedCount();
                            _historyEntry.Status = Status.Failed;
                            break;
                        case Status.Disapproved:
                            if (Root.ExecutionGraph.OnDisapproved != null)
                            {
                                var disapprovedTasks = NodesToTasks(Root.ExecutionGraph.OnDisapproved.Nodes);
                                RunTasks(Root.ExecutionGraph.OnDisapproved.Nodes, disapprovedTasks, true);
                            }
                            LogWorkflowFinished();
                            await _rep.IncrementDisapprovedCount();
                            _historyEntry.Status = Status.Disapproved;
                            break;
                    }
                    #endregion 
                }

                _historyEntry.StatusDate = DateTime.Now;
                _historyEntry.SetLog(Logs);
                var files = FilesPerTask.SelectMany(u => u.Value.Select(v => v.Path));
                _historyEntry.Files = JsonConvert.SerializeObject(files);
                await _rep.InsertHistoryEntry(_historyEntry);
                await _rep.DecrementRunningCount();
            }
            catch (ThreadAbortException)
            {
                _stopCalled = true;
            }
            catch (Exception e)
            {
                var msg = string.Format("An error occured while running the workflow. Error: {0}", this);
                Logger.LogError(msg, e);
                Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  ERROR - " + msg + "\r\n" + e);
            }
            finally
            {
                // Cleanup
                cleanUp();
            }
        }
        public async Task Continue()
        {
            try
            {
                if (Root.ExecutionGraph == null)
                {
                    await RunSequentialTasks();
                    if (IsWaitingForApproval)
                    {
                        //LogworkflowWaitForApproval
                        await _rep.IncrementPendingCount();
                        _historyEntry.Status = Status.Pending;
                    }
                    else
                    {
                        logResult();
                    }
                }
            }
            catch (ThreadAbortException)
            {
                _stopCalled = true;
            }
            catch (Exception e)
            {
                var msg = string.Format("An error occured while running the workflow. Error: {0}", this);
                lock (this)
                {
                    Logger.LogError(msg, e);
                    Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  ERROR - " + msg + "\r\n" + e);
                }
            }
            finally
            {
                cleanUp();
            }

        }
        public async Task<bool> Stop(IWorkflowRepository Database)
        {
            if (IsRunning)
            {
                try
                {
                    _stopCalled = true;
                    BackgroundJob.Delete(JobId);
                    IsWaitingForApproval = false;
                    await Database.DecrementRunningCount();
                    await Database.IncrementStoppedCount();
                    var entry = await Database.GetEntry(Root.Id);
                    entry.Status = Status.Stopped;
                    entry.StatusDate = DateTime.Now;
                    entry.SetLog(Logs);
                    await Database.UpdateEntry(entry);
                    _historyEntry.Status = Status.Stopped;
                    _historyEntry.StatusDate = DateTime.Now;
                    _historyEntry.SetLog(Logs);
                    await Database.InsertHistoryEntry(_historyEntry);
                    IsDisapproved = false;
                    Logs.Clear();
                    _ = Root.Jobs.TryRemove(InstanceId, out _);
                    return true;
                }
                catch (Exception e)
                {
                    var msg = string.Format("An error occured while stopping the workflow : {0}", this);
                    Logger.LogError(msg, e);
                    Logs.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "  ERROR - " + msg + "\r\n" + e);
                    _stopCalled = false;
                }
            }
            return false;
        }

        /// <summary>
        /// Approves the current workflow.
        /// </summary>
        public bool Approve()
        {
            if (!Root.IsApproval || !IsWaitingForApproval)
            {
                return false;
            }

            if (_currentTaskId >= Tasks.Count())
                return false;

            var task = Tasks[_currentTaskId];
            if (task.IsWaitingForApproval == false)
                return false;

            task.IsWaitingForApproval = false;
            IsWaitingForApproval = false;
            IsDisapproved = false;

            return true;
            //var dir = Path.Combine(_setting.ApprovalFolder, Root.Id.ToString(), task.Id.ToString());
            //Directory.CreateDirectory(dir);
            //File.WriteAllText(Path.Combine(dir, "task.approved"), "Task " + task.Id + " of the workflow " + Root.Id + " approved.");
        }

        /// <summary>
        /// Disapproves the current workflow.
        /// </summary>
        public async Task Disapprove()
        {
            if (Root.IsApproval && IsWaitingForApproval)
            {
                lock (this)
                {
                    IsDisapproved = true;
                    IsWaitingForApproval = false;
                    _historyEntry.Status = Status.Disapproved;
                }
                await _rep.IncrementDisapprovedCount();
                lock (this)
                {
                    LogWorkflowFinished();
                }

                await _rep.IncrementDisapprovedCount();
                lock (this)
                {
                    _historyEntry.Status = Status.Disapproved;
                }
                cleanUp();
            }
        }

        private void CreateTempFolder()
        {
            // WorkflowId/dd-MM-yyyy/HH-mm-ss-fff
            var wfTempFolder = Path.Combine(_setting.WexflowTempFolder, Root.Id.ToString(CultureInfo.CurrentCulture));
            if (!Directory.Exists(wfTempFolder)) Directory.CreateDirectory(wfTempFolder);

            var wfDayTempFolder = Path.Combine(wfTempFolder, string.Format("{0:yyyy-MM-dd}", DateTime.Now));
            if (!Directory.Exists(wfDayTempFolder)) Directory.CreateDirectory(wfDayTempFolder);
        }

        private Node GetStartupNode(IEnumerable<Node> nodes)
        {
            return nodes.First(n => n.ParentId == StartId);
        }

        private WorkflowTask GetTask(int id)
        {
            return Tasks.FirstOrDefault(t => t.Id == id);
        }

        private WorkflowTask GetTask(IEnumerable<WorkflowTask> tasks, int id)
        {
            return tasks.FirstOrDefault(t => t.Id == id);
        }
    }
}
