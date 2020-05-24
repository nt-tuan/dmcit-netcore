using DMCIT.Core.Entities.Core;
using DMCIT.Core.SharedKernel;
using System.Threading.Tasks;
public interface ITreeRepository
{
    Task LoadDecendants<E, R>(E entity)
    where E : TreeNodeEntity<E, R>
    where R : TreeRelationEntity<E, R>;
    Task LoadAncestors<E, R>(E entity)
     where E : TreeNodeEntity<E, R>
    where R : TreeRelationEntity<E, R>;
    Task LoadChildren<E, R>(E Entity) where E : TreeNodeEntity<E, R> where R : TreeRelationEntity<E, R>;
    Task LoadParent<E, R>(E Entity) where E : TreeNodeEntity<E, R> where R : TreeRelationEntity<E, R>;
    /// <summary>
    /// Assign parent to an entity node
    /// </summary>
    /// <typeparam name="E"></typeparam>
    /// <typeparam name="R"></typeparam>
    /// <param name="entity"></param>
    /// <param name="parent">if parent is null, entity will not have a parent</param>
    /// <returns></returns>
    Task AddParent<E, R>(E entity, E parent, AppUser actor) where E : TreeNodeEntity<E, R> where R : TreeRelationEntity<E, R>;

    Task LoadVSDecendants<E, R>(E entity)
where E : TreeNodeEntity<E, R>
where R : TreeRelationEntity<E, R>;
    Task LoadVSAncestors<E, R>(E entity)
     where E : TreeNodeEntity<E, R>
    where R : TreeRelationEntity<E, R>;
    Task LoadVSChildren<E, R>(E Entity) where E : TreeNodeEntity<E, R> where R : TreeRelationEntity<E, R>;
    Task LoadVSParent<E, R>(E Entity) where E : TreeNodeEntity<E, R> where R : TreeRelationEntity<E, R>;
    /// <summary>
    /// Assign parent to an entity node
    /// </summary>
    /// <typeparam name="E"></typeparam>
    /// <typeparam name="R"></typeparam>
    /// <param name="entity"></param>
    /// <param name="parent">if parent is null, entity will not have a parent</param>
    /// <returns></returns>
    Task AddVSParent<E, R>(E entity, E parent, AppUser actor) where E : TreeNodeEntity<E, R> where R : TreeRelationEntity<E, R>;
}