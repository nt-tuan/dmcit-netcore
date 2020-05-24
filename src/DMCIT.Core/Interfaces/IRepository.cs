using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DMCIT.Core.Interfaces
{
    public interface IRepository
    {
        IQueryable<T> ApplyDefaultWhere<T>(IQueryable<T> query, DateTime at) where T : BaseVersionControlEntity<T>;
        IQueryable<T> ApplyDefaultWhere<T>(IQueryable<T> query, int id, DateTime at) where T : BaseVersionControlEntity<T>;
        Func<T, bool> WhereEffective<T>(DateTime? at = null) where T : BaseVersionControlEntity<T>;
        Func<T, bool> WhereId<T>(int id) where T : BaseVersionControlEntity<T>;
        //Get by Id
        #region GET
        Task<T> GetById<T>(int id) where T : BaseEntity;
        Task<T> GetById<T>(int id, Func<IQueryable<T>, IQueryable<T>> preQuery) where T : BaseEntity;
        Task<T> GetById<T>(int id, DateTime? at = null) where T : BaseVersionControlEntity<T>;
        Task<T> GetById<T>(IQueryable<T> query, int id, DateTime? at = null) where T : BaseVersionControlEntity<T>;
        Task<T> GetOrigin<T>(int id, DateTime? at = null) where T : BaseVersionControlEntity<T>;
        Task<T> GetOrigin<T>(IQueryable<T> query, int id, DateTime? at = null) where T : BaseVersionControlEntity<T>;
        #endregion
        //List
        #region LIST
        Task<List<T>> ListVersionControl<T>(GetListParams<T> p) where T : BaseVersionControlEntity<T>;
        //Temperory!!! Have to fix its name later
        Task<List<T>> List<T>(GetListParams<T> p) where T : BaseEntity;
        Task<List<T>> ListRaw<T>(GetListParams<T> p) where T : Base;
        #endregion
        //Count
        #region COUNT
        Task<int> Count<T>(IDictionary<string, object> filter) where T : BaseEntity;
        Task<int> Count<T>(IQueryable<T> query, IDictionary<string, object> filter) where T : BaseEntity;
        Task<int> Count<T>(IDictionary<string, object> filter, DateTime? time = null) where T : BaseVersionControlEntity<T>;
        Task<int> Count<T>(IQueryable<T> query, IDictionary<string, object> filter, DateTime? time = null) where T : BaseVersionControlEntity<T>;
        Task<int> CountRaw<T>(GetListParams<T> p) where T : Base;
        Task<int> Count<T>(GetListParams<T> p) where T : BaseEntity;
        Task<int> CountDetail<T>(GetListParams<T> p) where T : BaseVersionControlEntity<T>;
        #endregion
        //Add
        #region ADD
        Task<T> Add<T>(T entity, AppUser appUser = null) where T : BaseEntity;
        Task<T> AddDetail<T>(T entity, DateTime? at = null, AppUser appUser = null) where T : BaseVersionControlEntity<T>;
        #endregion
        //Update
        #region UPDATE
        Task Update<T>(T entity, AppUser appUser = null) where T : BaseEntity;
        Task UpdateDetail<T>(T entity, DateTime? at = null, AppUser appUser = null) where T : BaseVersionControlEntity<T>;
        /// <summary>
        /// Update an entity without tracking this change. Be carefull of using this method!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="appUser"></param>
        /// <returns></returns>
        Task UpdateSilently<T>(T entity);
        #endregion
        //Delete
        #region DELETE
        Task Delete<T>(T entity, AppUser appUser = null) where T : BaseEntity;
        Task DeleteDetail<T>(T entity, DateTime? at = null, AppUser appUser = null) where T : BaseVersionControlEntity<T>;
        #endregion

        Task<List<T>> RawSqlQuery<T>(DbContext context, string query, SqlParameter[] parameters);
        Task<List<T>> RawSqlQuery<T>(DbContext context, string query, SqlParameter[] parameters, Func<IDataReader, List<T>> map);

        IQueryable<T> ApplyDefaultPaging<T>(IQueryable<T> query, int? page, int? pageRows, Expression<Func<T, object>> orderby, int? orderdir);

        IQueryable<T> ApplyFitlerToQuery<T>(IDictionary<string, object> filter, IQueryable<T> query);

        IQueryable<T> IncludeCreated<T>(IQueryable<T> query) where T : BaseVersionControlEntity<T>;

        Task<T> VSFirst<T>(Func<IQueryable<T>, IQueryable<T>> queryFunc, DateTime at) where T : BaseVersionControlEntity<T>;
        Task<T> First<T>(Func<IQueryable<T>, IQueryable<T>> queryFunc) where T : BaseEntity;
    }
}
