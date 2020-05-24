using System;

namespace DMCIT.Core.SharedKernel
{
    public class ProgressMessage
    {
        public enum ProgressType { ERROR = -1, WARNING = 0, SUCCESS = 1 };
        public DateTime TimeOccur { get; set; } = DateTime.Now;
        public string Message { get; set; }
        public ProgressType Type { get; set; }
    }
}
