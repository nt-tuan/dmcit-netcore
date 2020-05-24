using DMCIT.Core.Entities.Core;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using DMCIT.Infrastructure.Data.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        public enum ORDER_DIRECTION { DESCREASE, INSCREASE };
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region helps
        void ApplyMeta<T>(T entity, DateTime? at, AppUser user) where T : BaseVersionControlEntity<T>
        {
            entity.DateCreated = DateTime.Now;
            if (user == null)
                entity.CreatedById = null;
            else
                entity.CreatedById = user.Id;
            entity.DateEffective = at ?? DateTime.Now;
        }


        public IQueryable<T> ApplyFitlerToQuery<T>(IDictionary<string, object> filter, IQueryable<T> query)
        {
            var rs = query;
            if (filter != null)
            {
                var dict = filter;
                foreach (var item in dict)
                {
                    var value = item.Value;
                    if (value is int || value is long)
                    {
                        rs = rs.Where(u => EF.Property<int>(u, item.Key) == (int)value);
                    }
                    else if (value is int? || value is long?)
                    {
                        rs = rs.Where(u => EF.Property<int>(u, item.Key) == (int?)value);
                    }
                    else if (value is string && !String.IsNullOrEmpty((string)value))
                    {
                        rs = rs.Where(u => EF.Property<string>(u, item.Key) == (string)value);
                    }
                    else if (value is bool)
                    {
                        rs = rs.Where(u => EF.Property<bool>(u, item.Key) == (bool)value);
                    }
                    else if (value is DateTime || value is DateTime?)
                    {
                        if (value == null)
                        {
                            rs = rs.Where(u => EF.Property<DateTime>(u, item.Key) == null);
                        }
                        else
                        {
                            var date = (DateTime)value;
                            var beginDate = date.Date;
                            var endDate = beginDate.AddDays(1);
                            rs = rs.Where(u => EF.Property<DateTime>(u, item.Key) >= beginDate && EF.Property<DateTime>(u, item.Key) <= endDate);
                        }
                    }
                }
            }
            return rs;
        }

        public IQueryable<T> ApplyDefaultWhere<T>(IQueryable<T> query, DateTime at) where T : BaseVersionControlEntity<T>
        {
            var rs = query.Where(u => u.DateEffective <= at && (u.DateEnd == null || u.DateEnd > at));
            return rs;
        }
        public IQueryable<T> ApplyDefaultWhere<T>(IQueryable<T> query, int id, DateTime at) where T : BaseVersionControlEntity<T>
        {
            var rs = query.Where(u => u.Id == id || u.OriginId == id).Where(u => u.DateEffective <= at && (u.DateEnd == null || u.DateEnd > at));
            return rs;
        }
        public IQueryable<T> ApplyDefaultPaging<T>(IQueryable<T> query, int? page, int? pageRows, Expression<Func<T, object>> orderby, int? orderdir)
        {
            if (orderby == null)
            {
                orderby = u => "Id";
            }
            if (page != null && pageRows != null)
            {
                if (orderdir == null || orderdir == 1)
                {
                    query = query.OrderBy(orderby);
                }
                else
                {
                    query = query.OrderByDescending(orderby);
                }

                query = query.Skip(page.Value * (pageRows.Value)).Take(pageRows.Value);
            }
            return query;
        }

        async Task<List<T>> list<T>() where T : Base
        {
            var list = await _dbContext.Set<T>().AsNoTracking().ToListAsync();
            return list;
        }
        #endregion
        #region GET
        public async Task<T> GetById<T>(int id) where T : BaseEntity
        {
            var query = _dbContext.Set<T>();
            return await GetById(query, id);
        }

        public async Task<T> GetById<T>(IQueryable<T> query, int id) where T : BaseEntity
        {
            var entity = await query.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
            _dbContext.DetachAllEntities();
            return entity;
        }

        public async Task<T> GetById<T>(int id, DateTime? at) where T : BaseVersionControlEntity<T>
        {
            var query = _dbContext.Set<T>();
            return await GetById(query, id, at ?? DateTime.Now);
        }

        public async Task<T> GetById<T>(IQueryable<T> query, int id, DateTime? at) where T : BaseVersionControlEntity<T>
        {
            query = ApplyDefaultWhere(query, at ?? DateTime.Now);
            var entity = await query.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id || e.OriginId == id);
            _dbContext.DetachAllEntities();
            return entity;
        }
        #endregion
        #region LIST
        public async Task<List<T>> ListVersionControl<T>(GetListParams<T> p) where T : BaseVersionControlEntity<T>
        {
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking().AsQueryable();
            if (p.preExtension != null)
                query = p.preExtension(query);
            query = ApplyDefaultWhere(query, p.at);
            if (p.extension != null)
                query = p.extension(query);

            if (p.filter != null)
                query = ApplyFitlerToQuery<T>(p.filter, query);

            query = ApplyDefaultPaging<T>(query, p.page, p.pageRows, p.orderBy, p.orderDir);
            var list = await query.ToListAsync();
            return list;
        }

        public async Task<List<T>> List<T>(GetListParams<T> p) where T : BaseEntity
        {
            var now = DateTime.Now;
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking();
            if (p.preExtension != null)
                query = p.preExtension(query);
            query = query.Where(u => u.DateRemoved == null || u.DateRemoved > now);
            if (p != null && p.extension != null)
                query = p.extension(query);
            if (p != null && p.filter != null)
                query = ApplyFitlerToQuery<T>(p.filter, query);
            if (p != null)
                query = ApplyDefaultPaging<T>(query, p.page, p.pageRows, p.orderBy, p.orderDir);

            var list = await query.ToListAsync();
            return list;
        }

        public async Task<List<T>> ListRaw<T>(GetListParams<T> p) where T : Base
        {
            if (p == null)
                return await list<T>();
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking();
            if (p.preExtension != null)
                query = p.preExtension(query);
            if (p.extension != null)
                query = p.extension(query);
            if (p.filter != null)
                query = ApplyFitlerToQuery<T>(p.filter, query);
            query = ApplyDefaultPaging<T>(query, p.page, p.pageRows, p.orderBy, p.orderDir);

            var list = await query.ToListAsync();
            return list;
        }


        #endregion
        public async Task<T> Add<T>(T entity, AppUser user) where T : BaseEntity
        {
            entity.CreatedById = user != null ? user.Id : null;
            _dbContext.Set<T>().Add(entity);
            entity.DateCreated = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            //_dbContext.Entry<T>(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<T> AddDetail<T>(T entity, DateTime? at, AppUser user) where T : BaseVersionControlEntity<T>
        {
            entity.OriginId = null;
            entity.DateCreated = DateTime.Now;
            entity.DateEffective = at ?? DateTime.Now;
            entity.CreatedById = user?.Id;
            _dbContext.Set<T>().Add(entity);
            //_dbContext.Entry<T>(entity).State = EntityState.Detached;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        #region Count
        public async Task<int> Count<T>(IDictionary<string, object> filter) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();
            var count = await Count(query, filter);
            return count;
        }

        public async Task<int> Count<T>(IQueryable<T> query, IDictionary<string, object> filter) where T : BaseEntity
        {
            query = query.AsNoTracking();
            query = ApplyFitlerToQuery<T>(filter, query);
            var count = await query.CountAsync();
            return count;
        }

        public async Task<int> Count<T>(IDictionary<string, object> filter, DateTime? at) where T : BaseVersionControlEntity<T>
        {
            var query = _dbContext.Set<T>().AsQueryable();
            return await Count(query, filter, at);
        }


        public async Task<int> Count<T>(IQueryable<T> query, IDictionary<string, object> filter, DateTime? at = null) where T : BaseVersionControlEntity<T>
        {
            query = query.AsNoTracking();
            query = ApplyDefaultWhere<T>(query, at ?? DateTime.Now);
            query = ApplyFitlerToQuery<T>(filter, query);
            return await query.CountAsync();
        }
        #endregion

        #region Update
        public async Task Update<T>(T entity, AppUser appUser) where T : BaseEntity
        {
            entity.CreatedById = appUser == null ? null : appUser.Id;
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
            //_dbContext.Entry<T>(entity).State = EntityState.Detached;
        }

        public async Task UpdateDetail<T>(T entity, DateTime? at, AppUser appUser) where T : BaseVersionControlEntity<T>
        {
            at = at ?? DateTime.Now;
            var dup = entity.Dupplicate() as T;
            dup.Id = default;
            dup.DateEnd = at;
            dup.DateReplaced = at;
            ApplyMeta(entity, at, appUser);
            _dbContext.Set<T>().Add(dup);
            _dbContext.Set<T>().Update(entity);
            //_dbContext.Entry<T>(entity).State = EntityState.Detached;
            //_dbContext.Entry<T>(current).State = EntityState.Detached;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateSilently<T>(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

        }
        public async Task Delete<T>(T entity, AppUser user) where T : BaseEntity
        {
            var current = await GetById<T>(entity.Id);
            current.RemovedById = user?.Id;
            current.DateRemoved = DateTime.Now;
            _dbContext.Set<T>().Update(current);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ConstantDelete<T>(T entity, AppUser user) where T : Base
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        public async Task Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteDetail<T>(T entity, DateTime? at = null, AppUser appUser = null) where T : BaseVersionControlEntity<T>
        {
            at = at ?? DateTime.Now;
            entity.DateEnd = at;
            entity.DateRemoved = DateTime.Now;
            entity.RemovedById = appUser != null ? appUser.Id : null;
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Func<T, bool> WhereEffective<T>(DateTime? at) where T : BaseVersionControlEntity<T>
        {
            at = at ?? DateTime.Now;
            return (u => u.DateEffective <= at && (u.DateEnd == null || u.DateEnd > at));
        }

        public Func<T, bool> WhereId<T>(int id) where T : BaseVersionControlEntity<T>
        {
            return (e => e.Id == id || e.OriginId == id);
        }

        public async Task<T> GetOrigin<T>(int id, DateTime? at = null) where T : BaseVersionControlEntity<T>
        {
            //throw new NotImplementedException();
            var p = await GetOrigin<T>(_dbContext.Set<T>(), id, at);
            if (p == null)
                throw new EntityNotFound(typeof(T), id);
            return p;
        }

        public async Task<T> GetOrigin<T>(IQueryable<T> query, int id, DateTime? at = null) where T : BaseVersionControlEntity<T>
        {
            var p = await GetById<T>(query, id, at);
            if (p != null && p.OriginId != null)
            {
                var e = await _dbContext.Set<T>().Where(u => u.Id == p.OriginId).FirstOrDefaultAsync();
                return e;
            }
            return p;
        }

        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, dr[prop.Name], null);
                        }
                    }
                    catch
                    {

                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public async Task<List<T>> RawSqlQuery<T>(DbContext context, string query, SqlParameter[] parameters)
        {
            return await RawSqlQuery<T>(context, query, parameters, null);
        }

        public async Task<List<T>> RawSqlQuery<T>(DbContext context, string query, SqlParameter[] parameters, Func<IDataReader, List<T>> map)
        {
            if (map == null)
                map = DataReaderMapToList<T>;
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                command.Parameters.AddRange(parameters);
                context.Database.OpenConnection();

                using (var result = await command.ExecuteReaderAsync())
                {
                    var entities = map(result);
                    return entities;
                }
            }
        }

        public async Task<int> CountRaw<T>(GetListParams<T> p) where T : Base
        {
            var now = DateTime.Now;
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking();

            if (p.extension != null)
                query = p.extension(query);

            if (p.filter != null)
                query = ApplyFitlerToQuery<T>(p.filter, query);

            var count = await query.CountAsync();
            return count;
        }

        public async Task<int> Count<T>(GetListParams<T> p) where T : BaseEntity
        {
            var now = DateTime.Now;
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking().Where(u => u.DateRemoved == null || u.DateRemoved > now);

            if (p.extension != null)
                query = p.extension(query);

            if (p.filter != null)
                query = ApplyFitlerToQuery<T>(p.filter, query);

            var count = await query.CountAsync();
            return count;
        }

        public async Task<int> CountDetail<T>(GetListParams<T> p) where T : BaseVersionControlEntity<T>
        {
            IQueryable<T> query = _dbContext.Set<T>().AsNoTracking().AsQueryable();
            query = ApplyDefaultWhere(query, p.at);
            if (p.extension != null)
                query = p.extension(query);

            if (p.filter != null)
                query = ApplyFitlerToQuery<T>(p.filter, query);

            var count = await query.CountAsync();
            return count;
        }

        public IQueryable<T> IncludeCreated<T>(IQueryable<T> query) where T : BaseVersionControlEntity<T>
        {
            return query
                .Include(u => u.CreatedBy)
                    .ThenInclude(u => u.Employee)
                .Include(u => u.CreatedBy)
                    .ThenInclude(u => u.Customer);
        }

        public async Task<T> GetById<T>(int id, Func<IQueryable<T>, IQueryable<T>> preQuery) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsNoTracking();
            if (preQuery != null)
                query = preQuery(query);
            return await GetById(query, id);
        }

        public async Task<T> VSFirst<T>(Func<IQueryable<T>, IQueryable<T>> queryFunc, DateTime at) where T : BaseVersionControlEntity<T>
        {
            var query = _dbContext.Set<T>().AsQueryable();
            query = queryFunc(query);
            query = ApplyDefaultWhere(query, at);
            var entity = await query.FirstOrDefaultAsync();
            return entity;

        }

        public async Task<T> First<T>(Func<IQueryable<T>, IQueryable<T>> queryFunc) where T : BaseEntity
        {
            var query = _dbContext.Set<T>().AsQueryable();
            query = queryFunc(query);
            var entity = await query.FirstOrDefaultAsync();
            return entity;
        }
    }
}
