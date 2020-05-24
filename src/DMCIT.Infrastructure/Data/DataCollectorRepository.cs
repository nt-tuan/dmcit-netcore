using DMCIT.Core.Entities.Accounting;
using DMCIT.Core.Entities.Core;
using DMCIT.Core.Entities.DataCollector;

using DMCIT.Core.Interfaces;
using DMCIT.Core.Services;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Services;
using EFCore.BulkExtensions;
using Hangfire;
using Hangfire.Server;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class DataCollectorRepository : IDataCollectorRepository
    {
        private readonly IRepository _rep;
        private readonly ISettingRepository _isetting;
        private readonly AppDbContext _db;
        private readonly IDiary131Service _service;
        private readonly IProcessManagerService _processService;
        private readonly ICoreRepository _core;
        public DataCollectorRepository(IRepository rep, AppDbContext db, ISettingRepository setting, IProcessManagerService processService, IDiary131Service service, ICoreRepository core)
        {
            _rep = rep;
            _db = db;
            _isetting = setting;
            _service = service;
            _processService = processService;
            _core = core;
        }

        public async Task AddDistributedServer(DistributedServer server, AppUser actor)
        {
            _db.Add(server);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteDistributedServer(DistributedServer server, AppUser actor)
        {
            _db.Remove(server);
            await _db.SaveChangesAsync();
        }
        public async Task<List<DistributedServer>> GetDistributedServer(string code)
        {
            var e = await _db.DistributedServers
    .Where(u => u.DistributorCode == code)
    .Include(u => u.DistributedServerTableDefineds).ToListAsync();
            return e;
        }
        public async Task<DistributedServer> GetDistributedServer(string code, DateTime startTime, DateTime endTime)
        {
            var e = await _db.DistributedServers
                .Where(u => u.DistributorCode == code && u.DateEffective <= startTime && u.DateEnd >= endTime)
                .Include(u => u.DistributedServerTableDefineds).FirstOrDefaultAsync();
            return e;
        }

        public async Task<ICollection<DistributedServer>> GetDistributedServers(GetListParams<DistributedServer> param = null)
        {
            if (param == null)
            {
                param = new GetListParams<DistributedServer>();
                param.page = null;
                param.pageRows = null;
            }

            var query = _db.DistributedServers.AsNoTracking().AsQueryable();
            if (param.extension != null)
                query = param.extension(query);
            query = _rep.ApplyDefaultPaging(query, param.page, param.pageRows, param.orderBy, param.orderDir);
            var servers = await query.ToListAsync();
            return servers;
        }

        public async Task<ICollection<DistributedServer>> GetDistributedServersWithDetail()
        {
            return await _db.DistributedServers.Include(u => u.DistributedServerTableDefineds).ToListAsync();
        }

        public async Task<ICollection<Diary131>> GetDiary131(GetListParams<Diary131> p)
        {
            return await _rep.List(p);
        }

        public async Task UpdateDistributedServer(DistributedServer server, AppUser actor)
        {
            var entity = await _db.DistributedServers.Where(u => u.DistributorCode == server.DistributorCode).FirstOrDefaultAsync();
            if (entity == null)
                throw new Exception($"SERVER {server.DistributorCode} NOT FOUND");
            entity.DistributorCode = server.DistributorCode;
            entity.Description = server.Description;
            entity.ConnectionString = server.ConnectionString;
            entity.Servername = server.Servername;
            _db.Update(entity);
            await _db.SaveChangesAsync();
        }


        #region COLLECT DIARY131
        [AutomaticRetry(Attempts = 0)]
        public async Task LoadDiary131s(DistributedServer server, DateTime? start, DateTime end, AppUser actor, LoadDiary131EventCollection events)
        {
            if (start == null)
                start = new DateTime(1900, 1, 1);
            //Create Collecting Progress
            //LoadingDiary131Progress progress = new LoadingDiary131Progress(server, start.Value, end);
            events.OnBeginDownloadDiary131FromServer?.Invoke(server, start.Value, end);
            events.OnDownloadingDiary131FromServer?.Invoke();

            //Change Progress state to Loading
            var data = await GetDiary131FromSource(server, start.Value, end);

            //Change Progress state to Delete old items
            events.OnUpdatingDiary131FromServer?.Invoke();

            //Change Progress state to Update new items
            await DeleteDiary131(server, start.Value, end);
            await UpdateData(data, actor);

            //
            events.OnEndDownloadDiaryFromServer?.Invoke();
        }

        async Task<ICollection<Diary131>> GetDiary131FromSource(DistributedServer server, DateTime from, DateTime to)
        {
            //Temperary code because of disconected servers
            //await Task.Delay(5000);
            //return new List<Diary131>();

            //The truthly one
            var setting = _isetting.GetSettingStore().GetSetting<DataCollectorSetting>();
            var optionsBuilder = new DbContextOptionsBuilder();
            //var connString = _variables.RemoteConnectionString.Format(server.Servername, server.Database, server.Username, server.Password)
            var connString = server.ConnectionString;
            optionsBuilder.UseSqlServer(connString);
            List<Diary131> data;
            using (var dbContext = new DbContext(optionsBuilder.Options))
            {
                dbContext.Database.SetCommandTimeout(30);
                data = await _rep.RawSqlQuery(dbContext, setting.CollectDiary131Query, setting.GetCollectDiary131SqlParameters(server.DistributorCode, from, to), (dr) =>
                {
                    var list = new List<Diary131>();
                    while (dr.Read())
                    {
                        var obj = new Diary131();
                        obj.LoadData(dr);
                        list.Add(obj);
                    }
                    return list;
                });
            }
            return data;
        }

        async Task DeleteDiary131(DistributedServer server, DateTime from, DateTime to)
        {
            //await Task.Delay(5000);
            //return;

            await _db.BulkDeleteAsync(await _db.Diary131s.Where(u => u.DistributorCode == server.DistributorCode && u.ReceiptDate >= from && u.ReceiptDate < to).ToListAsync());
        }

        async Task UpdateData(ICollection<Diary131> data, AppUser actor)
        {
            //await Task.Delay(5000);
            //return;
            foreach (var i in data)
            {
                i.CreatedById = actor?.Id;
            }
            await _db.BulkInsertAsync(data.ToList());
        }
        [AutomaticRetry(Attempts = 0)]
        public async Task LoadDiary131s(DateTime start, DateTime end, AppUser actor, PerformContext context)
        {
            Func<Task> task = async () =>
            {
                await LoadDiary131s(start, end, actor, getPerformContextEventCollection(context));
            };
            await _processService.StartProcess(context, "SYNCHRONIZE DIARY131 FROM SERVERS", task, actor);
        }

        public async Task LoadDiary131s(DateTime start, DateTime end, AppUser actor, LoadDiary131EventCollection events)
        {
            var typeName = typeof(Diary131).FullName;
            var param = new GetListParams<DistributedServer>();
            param.page = null;
            param.pageRows = null;
            param.extension = query => query
            .Where(u => u.DateEffective <= start && u.DateEnd >= end)
            .Where(u => u.DistributedServerTableDefineds.Where(v => v.TableName == typeName).Any());
            var allServers = await GetDistributedServers(param);
            foreach (var sv in allServers)
            {
                await LoadDiary131s(sv, start, end, actor, events);
            }
        }

        private LoadDiary131EventCollection getPerformContextEventCollection(PerformContext context)
        {
            return new LoadDiary131EventCollection
            {
                OnFinish = async () => await _service.EndDownloadAllDiary131(context),
                OnBeginDownloadDiary131FromServer = async (sv, startTime, endTime) => await _service.Begin(sv, startTime, endTime, context),
                OnDownloadingDiary131FromServer = async () => await _service.Download(context),
                OnUpdatingDiary131FromServer = async () => await _service.Update(context),
                OnEndDownloadDiaryFromServer = async () => await _service.End(context)
            };
        }

        [AutomaticRetry(Attempts = 0)]
        public async Task LoadDiary131sProcess(AppUser actor, PerformContext context)
        {
            Func<Task> task = async () =>
            {
                await LoadDiary131s(actor, getPerformContextEventCollection(context));
            };

            await _processService.StartProcess(context, "SYNCHRONIZE DIARY131 FROM SERVERS", task, actor);
        }

        [AutomaticRetry(Attempts = 0)]
        public async Task LoadDiary131s(AppUser actor, LoadDiary131EventCollection events)
        {
            var ap = await _core.GetOpeningAccountPeriod();
            if (ap == null)
                throw new Exception("No opening accounting period found");
            var start = ap.AccountingStartTime ?? new DateTime(1900, 1, 1);
            var end = ap.AccountingEndTime;
            await LoadDiary131s(start, end, actor, events);
            if (events?.OnFinish != null)
            {
                await events.OnFinish.Invoke();
            }
        }
    }
    #endregion
}
