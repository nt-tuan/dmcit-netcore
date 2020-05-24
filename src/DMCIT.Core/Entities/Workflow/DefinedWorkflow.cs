using DMCIT.Core.SharedKernel;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DMCIT.Core.Entities.Workflow
{
    public class DefinedWorkflow : BaseEntity
    {
        public string Xml { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LauchType { get; set; }
        public string Period { get; set; }
        public string CronExpression { get; set; }
        public bool IsEnabled { get; set; }
        public bool StopWhenError { get; set; }
        public bool IsApproval { get; set; }
        public bool EnableParallelJobs { get; set; }
        public string TasksJSON { get; set; }
        public string ParametersJSON { get; set; }
        public string LocalVariablesJSON { get; set; }

        public Dictionary<string, WorkflowParameter> GetParameters()
        {
            try
            {
                return JsonConvert.DeserializeObject<Dictionary<string, WorkflowParameter>>(ParametersJSON);
            }
            catch
            {
                return new Dictionary<string, WorkflowParameter>();
            }
        }

        public Dictionary<string, string> GetLocalVariables()
        {
            try
            {
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(LocalVariablesJSON);
            }
            catch
            {
                return new Dictionary<string, string>();
            }
        }

        public Dictionary<int, DefinedWorkflowTask> GetWorkflowTasks()
        {
            try
            {
                return JsonConvert.DeserializeObject<Dictionary<int, DefinedWorkflowTask>>(TasksJSON);
            }
            catch
            {
                return new Dictionary<int, DefinedWorkflowTask>();
            }
        }

        public ICollection<UserWorkflow> UserWorkflows { get; set; }

    }
}
