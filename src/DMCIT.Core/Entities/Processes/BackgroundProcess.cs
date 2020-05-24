using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMCIT.Core.Entities.Processes
{
    public class BackgroundProcess : BaseEntity
    {
        public const string PENDING = "PENDING";
        public const string BEGIN_PROCESS = "BEGIN PROCESS";
        public const string PROCESSING = "PROCESSING";
        public const string END_PROCESS = "END_PROCESS";
        public const string PROCESS_INTERRUPTED = "PROCESS INTERRUPTED";

        public string Name { get; set; }
        public string JobId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Status { get; set; }
        public string Response { get; set; }
        public string DistributorCode { get; set; }

        [NotMapped]
        public BaseProgress RunningProgress { get; set; }

        [NotMapped]
        public IList<ProgressMessage> Messages { get; set; } = new List<ProgressMessage>();

        public BackgroundProcess()
        {
            StartTime = DateTime.Now;
            EndTime = null;
            Response = null;
            Status = PENDING;
        }

        public BackgroundProcess(string name, string jobId, AppUser actor) : base()
        {
            Name = name;
            JobId = jobId;
            CreatedBy = actor;
            CreatedById = actor == null ? null : actor.Id;
        }

        public void BeginProgress(BaseProgress progress)
        {
            if (RunningProgress != null)
            {
                EndProgress();
            }
            lock (this)
            {
                progress.Process = this;
                RunningProgress = progress;
            }
        }

        public void UpdateProgressState(BaseProgress progress)
        {
            lock (this)
            {
                RunningProgress.Update(progress);
            }
        }

        public void EndProgress()
        {
            lock (this)
            {
                RunningProgress = null;
            }
        }

        public void Copy(BackgroundProcess process)
        {
            Name = process.Name;
            StartTime = process.StartTime;
            EndTime = process.EndTime;
            Status = process.Status;
            Response = process.Response;
        }
    }
}
