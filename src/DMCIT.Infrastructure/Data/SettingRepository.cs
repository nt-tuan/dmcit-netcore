using DMCIT.Core.Entities;
using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.System;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class SettingRepository : ISettingRepository
    {
        private readonly IRepository _repos;
        private SettingStore _instance;
        public SettingRepository(IRepository repos)
        {
            _repos = repos;
            loadSetting().Wait();
        }

        async Task loadSetting()
        {
            _instance = new SettingStore();
            var entities = await GetSetting(DateTime.Now);
            var assembly = Assembly.GetAssembly(typeof(BaseSetting));

            var settingTypes = assembly.GetTypes().Where(u => u.BaseType == typeof(BaseSetting));

            foreach (var type in settingTypes)
            {
                var setting = Activator.CreateInstance(type) as BaseSetting;
                setting.LoadFromDb(entities);
                _instance.RegisterSetting(type, setting);
            }
        }

        public async Task<string> GetFileContent(string filepath)
        {
            return await File.ReadAllTextAsync(filepath);
        }

        public SettingStore GetSetting()
        {
            return _instance;
        }


        public async Task<ICollection<Setting>> GetSetting(DateTime? at)
        {
            var p = new GetListParams<Setting>();
            p.page = null;
            p.pageRows = null;
            p.orderBy = u => u.DateEffective;
            p.orderDir = (int)BaseEntity.ListOrder.DESC;
            p.at = at ?? DateTime.Now;
            var settings = await _repos.ListVersionControl(p);
            return settings;
        }

        async Task<Setting> GetSetting(Setting setting)
        {
            var p = new GetListParams<Setting>();
            p.extension = query => query.Where(u => u.Name == setting.Name && u.Module == setting.Module);
            var list = await _repos.ListVersionControl(p);
            return list.FirstOrDefault();
        }

        public async Task InitialDefaultSetting()
        {
            var assembly = Assembly.GetAssembly(typeof(BaseSetting));
            var settingTypes = assembly.GetTypes().Where(u => u.BaseType == typeof(BaseSetting));
            var settings = settingTypes.Select(u => Activator.CreateInstance(u) as BaseSetting);
            var settingLevels = new List<Setting>();
            foreach (var item in settings)
            {
                item.LoadDefault();
                settingLevels.AddRange(item.ToSettingEntities());
            }

            foreach (var item in settingLevels)
            {
                var p = new GetListParams<Setting>();
                p.extension = query => query.Where(u => u.Name == item.Name && u.Module == item.Module);
                var list = await _repos.ListVersionControl(p);
                if (list.Count > 0)
                    continue;
                //Add setting
                await _repos.AddDetail(item);
            }

            await loadSetting();
        }

        public async Task UpdateSetting(Setting setting, DateTime? at, AppUser actor, bool reload = true)
        {
            var entity = await GetSetting(setting);
            if (entity != null)
            {
                entity.Value = setting.Value;
                await _repos.UpdateDetail(entity, at, actor);
            }

            if (reload)
                await loadSetting();
        }

        SettingStore ISettingRepository.GetSettingStore()
        {
            return _instance;
        }

        public async Task UpdateSettings(ICollection<Setting> settings, DateTime? at, AppUser actor)
        {
            foreach (var item in settings)
            {
                await UpdateSetting(item, at, actor, false);
            }
            await loadSetting();
        }
    }
}
