using DMCIT.Core.Entities.Core;
using DMCIT.Core.Interfaces;
using DMCIT.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DMCIT.Infrastructure.Data
{
    public class TreeRepository : ITreeRepository
    {
        readonly AppDbContext _db;
        readonly IRepository _rep;

        public TreeRepository(AppDbContext db, IRepository rep)
        {
            _db = db;
            _rep = rep;
        }

        public async Task AddParent<E, R>(E entity, E parent, AppUser actor)
            where E : TreeNodeEntity<E, R>
            where R : TreeRelationEntity<E, R>
        {
            await LoadParent<E, R>(entity);
            await LoadDecendants<E, R>(entity);
            if (entity.ParentId != null)
            {
                var entityDecendants = entity.Decendants.Select(u => u.DecendanntId);
                var relation = await _db.Set<R>().Where(u => u.AncestorId == entity.ParentId && entityDecendants.Contains(u.DecendanntId)).ToListAsync();
                foreach (var item in relation)
                    await _rep.Delete(item, actor);
            }

        }

        public Task AddVSParent<E, R>(E entity, E parent, AppUser actor)
            where E : TreeNodeEntity<E, R>
            where R : TreeRelationEntity<E, R>
        {
            throw new NotImplementedException();
        }

        public Task LoadAncestors<E, R>(E entity)
            where E : TreeNodeEntity<E, R>
            where R : TreeRelationEntity<E, R>
        {
            throw new NotImplementedException();
        }

        public Task LoadChildren<E, R>(E Entity)
            where E : TreeNodeEntity<E, R>
            where R : TreeRelationEntity<E, R>
        {
            throw new NotImplementedException();
        }

        public async Task LoadDecendants<E, R>(E entity)
            where E : TreeNodeEntity<E, R>
            where R : TreeRelationEntity<E, R>
        {
            throw new NotImplementedException();
        }

        public Task LoadParent<E, R>(E Entity)
            where E : TreeNodeEntity<E, R>
            where R : TreeRelationEntity<E, R>
        {
            throw new NotImplementedException();
        }

        public Task LoadVSAncestors<E, R>(E entity)
            where E : TreeNodeEntity<E, R>
            where R : TreeRelationEntity<E, R>
        {
            throw new NotImplementedException();
        }

        public Task LoadVSChildren<E, R>(E Entity)
            where E : TreeNodeEntity<E, R>
            where R : TreeRelationEntity<E, R>
        {
            throw new NotImplementedException();
        }

        public Task LoadVSDecendants<E, R>(E entity)
            where E : TreeNodeEntity<E, R>
            where R : TreeRelationEntity<E, R>
        {
            throw new NotImplementedException();
        }

        public Task LoadVSParent<E, R>(E Entity)
            where E : TreeNodeEntity<E, R>
            where R : TreeRelationEntity<E, R>
        {
            throw new NotImplementedException();
        }
    }
}
