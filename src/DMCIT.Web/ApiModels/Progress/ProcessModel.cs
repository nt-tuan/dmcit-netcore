using DMCIT.Core.Entities.Processes;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;

namespace DMCIT.Web.ApiModels.Progress
{
    public class ProcessModel
    {
        public string jobId { get; set; }
        public string name { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
        public IList<ProgressMessage> messages { get; set; }
        public ProgressModel progress { get; set; }
        public ProcessModel(BackgroundProcess process)
        {
            name = process.Name;
            startTime = process.StartTime;
            endTime = process.EndTime;
            messages = process.Messages;
            jobId = process.JobId;
            if (process.RunningProgress != null)
            {
                progress = new ProgressModel(process.RunningProgress);
            }
            //process
        }
    }
}
