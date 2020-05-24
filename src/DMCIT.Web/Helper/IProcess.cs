using DMCIT.Core.Entities.Processes;
using DMCIT.Web.Hubs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Web.Helper.CollectingProcess
{
    public interface IProcess
    {
        Task Report();
        Task<BackgroundProcess> DoWork();
        string GetId();
        string GetTitle();
        ProcessState GetState();
        ICollection<string> GetMessages();
    }
}
