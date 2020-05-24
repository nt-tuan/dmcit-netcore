using DMCIT.Core.Entities.System;

namespace DMCIT.Core.Entities.Workflow
{
    public class WorkflowSetting : BaseSetting
    {
        /// <summary>
        /// Maximum retries of loading a workflow.
        /// </summary>
        public int MaxRetries { get; set; }
        public int RetryTimeout { get; set; }
        public string SettingFiles { get; set; }
        public string TempFolder { get; set; }
        public string TasksFolder { get; set; }
        public string WexflowTempFolder { get; set; }
        public string WorkflowsTempFolder { get; set; }
        public string ApprovalFolder { get; set; }
        public string XsdPath { get; set; }
        public string TasksNamesFile { get; set; }
        public string TasksSettingsFile { get; set; }
        /// <summary>
        /// Global variables file.
        /// </summary>
        public string GlobalVariablesFile { get; private set; }
        public override void LoadDefault()
        {
            GlobalVariablesFile = "AppData\\Workflows\\GlobalVariables.xml";
            MaxRetries = 5;
            RetryTimeout = 700;
            XsdPath = "AppData\\Workflows\\Workflow.xsd";
            WexflowTempFolder = "AppData\\Wexflows\\Temp";
            WorkflowsTempFolder = "AppData\\Workflows\\Temp";
        }
    }
}
