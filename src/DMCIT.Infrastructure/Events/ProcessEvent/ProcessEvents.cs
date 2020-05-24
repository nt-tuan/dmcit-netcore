using DMCIT.Core.SharedKernel;
using Hangfire.Server;

namespace DMCIT.Infrastructure.Events.ProcessEvent
{
    public class ProgressEvent : BaseDomainEvent
    {
        public BaseProgress Progress { get; set; }
        public ProgressEvent(BaseProgress progress, PerformContext context)
        {
            Progress = progress;
            Context = context;
        }
    }

    public class ProgressBeginEvent : ProgressEvent
    {
        public ProgressBeginEvent(BaseProgress progress, PerformContext context) : base(progress, context) { }
    }
    public class ProgressChangeEvent : ProgressEvent
    {
        public ProgressChangeEvent(BaseProgress progress, PerformContext context) : base(progress, context) { }
    }

    public class ProgressEndEvent : ProgressEvent
    {
        public string Message { get; set; }
        public ProgressEndEvent(BaseProgress progress, string message, PerformContext context) : base(progress, context)
        {
            Message = message;
        }
    }

    public class ProgressErrorEvent : ProgressEvent
    {
        public string Reason { get; set; }
        public ProgressErrorEvent(BaseProgress progress, PerformContext context, string reason) : base(progress, context)
        {
            Reason = reason;
        }
    }
}
