using DMCIT.Core.SharedKernel;
using System;

namespace DMCIT.Web.ApiModels.Progress
{
    public class ProgressModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int type { get; set; }
        public double? percent { get; set; }
        public DateTime timeOccur { get; set; }
        public string jobId { get; set; }
        public DateTime startTime { get; set; }
        public DateTime? endTime { get; set; }
        public ProgressModel() { }
        public ProgressModel(BaseProgress progress)
        {
            title = progress.Title;
            description = progress.Description;
            percent = progress.Percent;
            timeOccur = progress.LastChange;
            jobId = progress?.Process?.JobId;
            startTime = progress.StartTime;
            endTime = progress.EndTime;
            id = progress.Id;
            type = (int)progress.Type;
        }
    }
}
