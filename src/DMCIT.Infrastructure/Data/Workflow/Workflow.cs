using Autofac;
using DMCIT.Core.Entities.Workflow;
using DMCIT.Infrastructure.Data.Workflow.ExecutionGraph;
using DMCIT.Infrastructure.Data.Workflow.ExecutionGraph.Flowchart;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace DMCIT.Infrastructure.Data.Workflow
{
    public class WorkflowRunResult
    {
        public bool error { get; set; }
        public bool success { get; set; }
        public bool warning { get; set; }

    }
    /// <summary>
    /// Workflow.
    /// </summary>
    public class Workflow
    {
        /// <summary>
        /// Default parent node id to start with in the execution graph.
        /// </summary>
        public const int StartId = -1;
        //ILogger Logger;
        /// <summary>
        /// Database ID.
        /// </summary>

        public DefinedWorkflow DbEntity { get; set; }
        //private readonly WorkflowSetting Setting;
        public int Id { get; private set; }
        /// <summary>
        /// Workflow name.
        /// </summary>
        public string Name
        {
            get
            {
                return DbEntity.Name;
            }
        }
        /// <summary>
        /// Workflow description.
        /// </summary>
        public string Description
        {
            get
            {
                return DbEntity.Name;
            }
        }
        /// <summary>
        /// Workflow lanch type.
        /// </summary>
        public LaunchType LaunchType
        {
            get
            {
                return (LaunchType)DbEntity.LauchType;
            }
        }
        /// <summary>
        /// Workflow period.
        /// </summary>
        public TimeSpan Period
        {
            get
            {
                return TimeSpan.Parse(DbEntity.Period);
            }
        }
        /// <summary>
        /// Cron expression
        /// </summary>
        public string CronExpression
        {
            get
            {
                return DbEntity.CronExpression;
            }
        }
        /// <summary>
        /// Shows whether this workflow is enabled or not.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return DbEntity.IsEnabled;
            }
        }

        /// <summary>
        /// Shows whether this workflow has to stop when an error occurs
        /// </summary>
        public bool StopWhenError
        {
            get
            {
                return DbEntity.StopWhenError;
            }
        }

        /// <summary>
        /// Shows whether this workflow is an approval workflow or not.
        /// </summary>
        public bool IsApproval
        {
            get
            {
                return DbEntity.IsApproval;
            }
        }
        /// <summary>
        /// Shows whether workflow jobs are executed in parallel. Otherwise jobs are queued. Defaults to true.
        /// </summary>
        public bool EnableParallelJobs
        {
            get
            {
                return DbEntity.EnableParallelJobs;
            }
        }

        /// <summary>
        /// Workflow tasks.
        /// </summary>
        public Dictionary<int, DefinedWorkflowTask> Tasks { get; private set; }

        /// <summary>
        /// Required parameters to start workflow
        /// </summary>
        public Dictionary<string, WorkflowParameter> Parameters { get; private set; }

        /// <summary>
        /// Log tag.
        /// </summary>

        /// <summary>
        /// Xml Namespace Manager.
        /// </summary>
        public XmlNamespaceManager XmlNamespaceManager { get; private set; }
        /// <summary>
        /// Execution graph.
        /// </summary>
        public Graph ExecutionGraph { get; private set; }
        /// <summary>
        /// Shows whether the execution graph is empty or not.
        /// </summary>
        public bool IsExecutionGraphEmpty { get; private set; }
        /// <summary>
        /// Hashtable used as shared memory for tasks.
        /// </summary>

        /// <summary>
        /// Global variables.
        /// </summary>
        public Variable[] GlobalVariables { get; private set; }
        /// <summary>
        /// Local variables.
        /// </summary>
        public Variable[] LocalVariables { get; private set; }

        /// <summary>
        /// Workflow jobs.
        /// </summary>
        public ConcurrentDictionary<Guid, WorkingWorkflow> Jobs { get; private set; }

        public ConcurrentDictionary<Guid, WorkingWorkflow> ReadyJobs { get; private set; }
        /// <summary>
        /// Creates a new workflow.
        /// </summary>
        /// <param name="jobId">First job Id.</param>
        /// <param name="jobs">Workflow jobs.</param>
        /// <param name="dbId">Database ID.</param>
        /// <param name="xml">XML of the workflow.</param>
        /// <param name="wexflowTempFolder">Wexflow temp folder.</param>
        /// <param name="workflowsTempFolder">Workflows temp folder.</param>
        /// <param name="tasksFolder">Tasks folder.</param>
        /// <param name="approvalFolder">Approval folder.</param>
        /// <param name="xsdPath">XSD path.</param>
        /// <param name="database">Database.</param>
        /// <param name="globalVariables">Global variables.</param>
        /// 
        public Workflow() { }
        public Workflow(
            WorkflowSetting setting,
            ConcurrentDictionary<Guid, WorkingWorkflow> jobs,
            DefinedWorkflow definedWorkflow,
            Variable[] globalVariables)
        {
            Jobs = jobs;
            ReadyJobs = new ConcurrentDictionary<Guid, WorkingWorkflow>();
            //Setting = setting;
            DbEntity = definedWorkflow;
            GlobalVariables = globalVariables;
            Id = definedWorkflow.Id;

            LoadLocalVariables();
            Load();
        }

        /// <summary>
        /// Returns informations about this workflow.
        /// </summary>
        /// <returns>Informations about this workflow.</returns>
        public override string ToString()
        {
            return string.Format("{{id: {0}, name: {1}, enabled: {2}, launchType: {3}}}", Id, Name, IsEnabled, LaunchType);
        }

        private void LoadLocalVariables()
        {
            LocalVariables = JsonConvert.DeserializeObject<Dictionary<string, string>>(DbEntity.LocalVariablesJSON).Select(u => new Variable
            {
                Key = u.Key,
                Value = u.Value
            }).ToArray();
        }

        protected void Load()
        {
            loadTasks();
            #region excution graph
            /*
            if (xExectionGraph != null)
            {
                var taskNodes = GetTaskNodes(xExectionGraph);

                // Check startup node, parallel tasks and infinite loops
                if (taskNodes.Any()) CheckStartupNode(taskNodes, "Startup node with parentId=-1 not found in ExecutionGraph execution graph.");
                CheckParallelTasks(taskNodes, "Parallel tasks execution detected in ExecutionGraph execution graph.");
                CheckInfiniteLoop(taskNodes, "Infinite loop detected in ExecutionGraph execution graph.");

                // OnSuccess
                GraphEvent onSuccess = null;
                var xOnSuccess = xExectionGraph.XPathSelectElement("wf:OnSuccess", XmlNamespaceManager);
                if (xOnSuccess != null)
                {
                    var onSuccessNodes = GetTaskNodes(xOnSuccess);
                    CheckStartupNode(onSuccessNodes, "Startup node with parentId=-1 not found in OnSuccess execution graph.");
                    CheckParallelTasks(onSuccessNodes, "Parallel tasks execution detected in OnSuccess execution graph.");
                    CheckInfiniteLoop(onSuccessNodes, "Infinite loop detected in OnSuccess execution graph.");
                    onSuccess = new GraphEvent(onSuccessNodes);
                }

                // OnWarning
                GraphEvent onWarning = null;
                var xOnWarning = xExectionGraph.XPathSelectElement("wf:OnWarning", XmlNamespaceManager);
                if (xOnWarning != null)
                {
                    var onWarningNodes = GetTaskNodes(xOnWarning);
                    CheckStartupNode(onWarningNodes, "Startup node with parentId=-1 not found in OnWarning execution graph.");
                    CheckParallelTasks(onWarningNodes, "Parallel tasks execution detected in OnWarning execution graph.");
                    CheckInfiniteLoop(onWarningNodes, "Infinite loop detected in OnWarning execution graph.");
                    onWarning = new GraphEvent(onWarningNodes);
                }

                // OnError
                GraphEvent onError = null;
                var xOnError = xExectionGraph.XPathSelectElement("wf:OnError", XmlNamespaceManager);
                if (xOnError != null)
                {
                    var onErrorNodes = GetTaskNodes(xOnError);
                    CheckStartupNode(onErrorNodes, "Startup node with parentId=-1 not found in OnError execution graph.");
                    CheckParallelTasks(onErrorNodes, "Parallel tasks execution detected in OnError execution graph.");
                    CheckInfiniteLoop(onErrorNodes, "Infinite loop detected in OnError execution graph.");
                    onError = new GraphEvent(onErrorNodes);
                }

                // OnDisapproved
                GraphEvent onDisapproved = null;
                var xOnDispproved = xExectionGraph.XPathSelectElement("wf:OnRejected", XmlNamespaceManager);
                if (xOnDispproved != null)
                {
                    var onDisapproveNodes = GetTaskNodes(xOnDispproved);
                    CheckStartupNode(onDisapproveNodes, "Startup node with parentId=-1 not found in OnError execution graph.");
                    CheckParallelTasks(onDisapproveNodes, "Parallel tasks execution detected in OnError execution graph.");
                    CheckInfiniteLoop(onDisapproveNodes, "Infinite loop detected in OnError execution graph.");
                    onDisapproved = new GraphEvent(onDisapproveNodes);
                }


                ExecutionGraph = new Graph(taskNodes, onSuccess, onWarning, onError, onDisapproved);
            }
            */
            #endregion
        }

        private void loadTasks()
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

            var tasksDict = JsonConvert.DeserializeObject<Dictionary<int, DefinedWorkflowTask>>(DbEntity.TasksJSON);
            Tasks = tasksDict;
        }

        private Node[] GetTaskNodes(XElement xExectionGraph)
        {
            var nodes = xExectionGraph
                .Elements()
                .Where(xe => xe.Name.LocalName != "OnSuccess" && xe.Name.LocalName != "OnWarning" && xe.Name.LocalName != "OnError" && xe.Name.LocalName != "OnRejected")
                .Select(XNodeToNode)
                .ToArray();

            return nodes;
        }

        private If XIfToIf(XElement xIf)
        {
            var xId = xIf.Attribute("id");
            if (xId == null) throw new Exception("If id attribute not found.");
            var id = int.Parse(xId.Value);
            var xParent = xIf.Attribute("parent");
            if (xParent == null) throw new Exception("If parent attribute not found.");
            var parentId = int.Parse(xParent.Value);
            var xIfId = xIf.Attribute("if");
            if (xIfId == null) throw new Exception("If attribute not found.");
            var ifId = int.Parse(xIfId.Value);

            // Do nodes
            var doNodes = xIf.XPathSelectElement("wf:Do", XmlNamespaceManager)
                .Elements()
                .Select(XNodeToNode)
                .ToArray();

            CheckStartupNode(doNodes, "Startup node with parentId=-1 not found in DoIf>Do execution graph.");
            CheckParallelTasks(doNodes, "Parallel tasks execution detected in DoIf>Do execution graph.");
            CheckInfiniteLoop(doNodes, "Infinite loop detected in DoIf>Do execution graph.");

            // Otherwise nodes
            Node[] elseNodes = null;
            var xElse = xIf.XPathSelectElement("wf:Else", XmlNamespaceManager);
            if (xElse != null)
            {
                elseNodes = xElse
                    .Elements()
                    .Select(XNodeToNode)
                    .ToArray();

                CheckStartupNode(elseNodes, "Startup node with parentId=-1 not found in DoIf>Otherwise execution graph.");
                CheckParallelTasks(elseNodes, "Parallel tasks execution detected in DoIf>Otherwise execution graph.");
                CheckInfiniteLoop(elseNodes, "Infinite loop detected in DoIf>Otherwise execution graph.");
            }

            return new If(id, parentId, ifId, doNodes, elseNodes);
        }

        private While XWhileToWhile(XElement xWhile)
        {
            var xId = xWhile.Attribute("id");
            if (xId == null) throw new Exception("While Id attribute not found.");
            var id = int.Parse(xId.Value);
            var xParent = xWhile.Attribute("parent");
            if (xParent == null) throw new Exception("While parent attribute not found.");
            var parentId = int.Parse(xParent.Value);
            var xWhileId = xWhile.Attribute("while");
            if (xWhileId == null) throw new Exception("While attribute not found.");
            var whileId = int.Parse(xWhileId.Value);

            var doNodes = xWhile
                .Elements()
                .Select(XNodeToNode)
                .ToArray();

            CheckStartupNode(doNodes, "Startup node with parentId=-1 not found in DoWhile>Do execution graph.");
            CheckParallelTasks(doNodes, "Parallel tasks execution detected in DoWhile>Do execution graph.");
            CheckInfiniteLoop(doNodes, "Infinite loop detected in DoWhile>Do execution graph.");

            return new While(id, parentId, whileId, doNodes);
        }

        private Switch XSwitchToSwitch(XElement xSwitch)
        {
            var xId = xSwitch.Attribute("id");
            if (xId == null) throw new Exception("Switch Id attribute not found.");
            var id = int.Parse(xId.Value);
            var xParent = xSwitch.Attribute("parent");
            if (xParent == null) throw new Exception("Switch parent attribute not found.");
            var parentId = int.Parse(xParent.Value);
            var xSwitchId = xSwitch.Attribute("switch");
            if (xSwitchId == null) throw new Exception("Switch attribute not found.");
            var switchId = int.Parse(xSwitchId.Value);

            var cases = xSwitch
                .XPathSelectElements("wf:Case", XmlNamespaceManager)
                .Select(xCase =>
                {
                    var xValue = xCase.Attribute("value");
                    if (xValue == null) throw new Exception("Case value attribute not found.");
                    var val = xValue.Value;

                    var nodes = xCase
                        .Elements()
                        .Select(XNodeToNode)
                        .ToArray();

                    var nodeName = string.Format("Switch>Case(value={0})", val);
                    CheckStartupNode(nodes, "Startup node with parentId=-1 not found in " + nodeName + " execution graph.");
                    CheckParallelTasks(nodes, "Parallel tasks execution detected in " + nodeName + " execution graph.");
                    CheckInfiniteLoop(nodes, "Infinite loop detected in " + nodeName + " execution graph.");

                    return new Case(val, nodes);
                });

            var xDefault = xSwitch.XPathSelectElement("wf:Default", XmlNamespaceManager);
            if (xDefault == null) return new Switch(id, parentId, switchId, cases, null);
            var @default = xDefault
                .Elements()
                .Select(XNodeToNode)
                .ToArray();

            if (@default.Length > 0)
            {
                CheckStartupNode(@default,
                    "Startup node with parentId=-1 not found in Switch>Default execution graph.");
                CheckParallelTasks(@default, "Parallel tasks execution detected in Switch>Default execution graph.");
                CheckInfiniteLoop(@default, "Infinite loop detected in Switch>Default execution graph.");
            }

            return new Switch(id, parentId, switchId, cases, @default);
        }

        private Node XNodeToNode(XElement xNode)
        {
            switch (xNode.Name.LocalName)
            {
                case "Task":
                    var xId = xNode.Attribute("id");
                    if (xId == null) throw new Exception("Task id not found.");
                    var id = int.Parse(xId.Value);

                    var xParentId = xNode.XPathSelectElement("wf:Parent", XmlNamespaceManager)
                        .Attribute("id");

                    if (xParentId == null) throw new Exception("Parent id not found.");
                    var parentId = int.Parse(xParentId.Value);

                    var node = new Node(id, parentId);
                    return node;
                case "If":
                    return XIfToIf(xNode);
                case "While":
                    return XWhileToWhile(xNode);
                case "Switch":
                    return XSwitchToSwitch(xNode);
                default:
                    throw new Exception(xNode.Name.LocalName + " is not supported.");
            }
        }

        private void CheckStartupNode(Node[] nodes, string errorMsg)
        {
            if (nodes == null) throw new ArgumentNullException(); // new ArgumentNullException(nameof(nodes))
            if (nodes.All(n => n.ParentId != StartId)) throw new Exception(errorMsg);
        }

        private void CheckParallelTasks(Node[] taskNodes, string errorMsg)
        {
            bool parallelTasksDetected = false;
            foreach (var taskNode in taskNodes)
            {
                if (taskNodes.Count(n => n.ParentId == taskNode.Id) > 1)
                {
                    parallelTasksDetected = true;
                    break;
                }
            }

            if (parallelTasksDetected)
            {
                throw new Exception(errorMsg);
            }
        }

        private void CheckInfiniteLoop(Node[] taskNodes, string errorMsg)
        {
            var startNode = taskNodes.FirstOrDefault(n => n.ParentId == StartId);

            if (startNode != null)
            {
                var infiniteLoopDetected = CheckInfiniteLoop(startNode, taskNodes);

                if (!infiniteLoopDetected)
                {
                    foreach (var taskNode in taskNodes.Where(n => n.Id != startNode.Id))
                    {
                        infiniteLoopDetected |= CheckInfiniteLoop(taskNode, taskNodes);

                        if (infiniteLoopDetected) break;
                    }
                }

                if (infiniteLoopDetected)
                {
                    throw new Exception(errorMsg);
                }
            }
        }

        private bool CheckInfiniteLoop(Node startNode, Node[] taskNodes)
        {
            foreach (var taskNode in taskNodes.Where(n => n.ParentId != startNode.ParentId))
            {
                if (taskNode.Id == startNode.Id)
                {
                    return true;
                }
            }

            return false;
        }

        private string GetWorkflowAttribute(XDocument xdoc, string attr)
        {
            var xAttribute = xdoc.XPathSelectElement("/wf:Workflow", XmlNamespaceManager).Attribute(attr);
            if (xAttribute != null)
            {
                return xAttribute.Value;
            }

            throw new Exception("Workflow attribute " + attr + "not found.");
        }

        private string GetWorkflowSetting(XDocument xdoc, string name, bool throwExceptionIfNotFound)
        {
            var xSetting = xdoc
                .XPathSelectElement(
                    string.Format("/wf:Workflow/wf:Settings/wf:Setting[@name='{0}']", name),
                    XmlNamespaceManager);

            if (xSetting != null)
            {
                var xAttribute = xSetting.Attribute("value");
                if (xAttribute != null)
                {
                    return xAttribute.Value;
                }
                else if (throwExceptionIfNotFound)
                {
                    throw new Exception("Workflow setting " + name + " not found.");
                }
            }
            else if (throwExceptionIfNotFound)
            {
                throw new Exception("Workflow setting " + name + " not found.");
            }

            return string.Empty;
        }

        public void SetWorkflowSetting(XDocument xdoc, string name, string value)
        {
            var e = xdoc.Root.XPathSelectElement($"wf:Settings/wf:Setting[@name='{name}']",
               XmlNamespaceManager);
            if (e == null)
            {
                XNamespace xn = "urn:wexflow-schema";
                xdoc.Root.XPathSelectElement("wf:Settings", XmlNamespaceManager)
                    .Add(new XElement(xn + "Setting"
                            , new XAttribute("name", name)
                            , new XAttribute("value", value)));
            }
            else
                e.Attribute("value").Value = value;
        }
    }
}
