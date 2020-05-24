using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.Processes;
using System;

namespace DMCIT.Core.SharedKernel
{
    public abstract class BaseProgress
    {
        public enum ProgressState { ERROR = -1, PENDING = 0, WORKING = 1, DONE = 2, WAIT_APPROVAL = 3 }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double? Percent { get; set; }
        int? Total { get; set; }
        int Count { get; set; }
        public ProgressState Type { get; set; } = ProgressState.PENDING;
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime LastChange { get; set; }
        public AppUser CreatedBy { get; set; }
        public BackgroundProcess Process { get; set; }

        public BaseProgress()
        {
            LastChange = DateTime.Now;
        }

        public void Update(BaseProgress progress)
        {
            Title = progress.Title;
            Description = progress.Description;
            Percent = progress.Percent;
            LastChange = DateTime.Now;
        }

        public virtual void SetBegin()
        {
            Type = ProgressState.WORKING;
            StartTime = DateTime.Now;
            LastChange = DateTime.Now;
        }

        public virtual void SetEnd()
        {
            Type = ProgressState.DONE;
            LastChange = DateTime.Now;
            EndTime = DateTime.Now;
        }

        public virtual void SetError()
        {
            Type = ProgressState.ERROR;
            LastChange = DateTime.Now;
            EndTime = DateTime.Now;
        }

        public virtual void SetApproval()
        {
            Type = ProgressState.WAIT_APPROVAL;
            LastChange = DateTime.Now;
        }

        public void SetDescription(string value)
        {
            Description = value;
            LastChange = DateTime.Now;
        }

        void UpdatePercent()
        {
            Percent = Count * 100.0 / Total;
        }

        public void Inscrease(int n)
        {
            if (Count + n > Total)
                Count = Total.Value;
            else
                Count += n;
            UpdatePercent();
        }

        public void InitCount(int total)
        {
            Total = total;
            Percent = 0;
            Count = 0;
        }
    }
}
