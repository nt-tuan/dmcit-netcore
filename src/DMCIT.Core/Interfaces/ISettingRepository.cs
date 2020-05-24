using DMCIT.Core.Entities;
using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public interface ISettingRepository
    {
        SettingStore GetSettingStore();
        Task<ICollection<Setting>> GetSetting(DateTime? at);
        Task<string> GetFileContent(string filepath);
        Task UpdateSetting(Setting setting, DateTime? at, AppUser actor, bool reload);
        Task UpdateSettings(ICollection<Setting> settings, DateTime? at, AppUser actor);
        Task InitialDefaultSetting();
    }
}
