using System.Collections.Generic;

namespace DMCIT.Core.SharedKernel
{
    //Node entity of a graph
    public class TreeNodeEntity<E, T> : BaseEntity
        where E : TreeNodeEntity<E, T>
        where T : TreeRelationEntity<E, T>
    {
        public int? ParentId { get; set; }
        //Direct parent
        public E Parent { get; set; }
        //Direct children
        public ICollection<E> Children { get; set; }
        //Collection of decendants
        public ICollection<T> Decendants { get; set; }
        //Collection of accestors
        public ICollection<T> Ancestors { get; set; }
    }
    public class VSTreeNodeEntity<E, T> : BaseVersionControlEntity<E>
    {
        public int? ParentId { get; set; }
        public E Parent { get; set; }
        public ICollection<E> Children { get; set; }
        public ICollection<T> Decendants { get; set; }
        public ICollection<T> Ancestors { get; set; }
    }
    public class TreeRelationEntity<T, R> : BaseEntity
        where R : TreeRelationEntity<T, R>
        where T : TreeNodeEntity<T, R>
    {
        public int AncestorId { get; set; }
        public T Ancestor { get; set; }
        public int DecendanntId { get; set; }
        public T Decendannt { get; set; }
        public int Level { get; set; }
    }
    public class VSTreeRelationEntity<T, R> : BaseVersionControlEntity<R>
        where R : VSTreeRelationEntity<T, R>
        where T : VSTreeNodeEntity<T, R>
    {
        public int AncestorId { get; set; }
        public T Ancestor { get; set; }
        public int DecendanntId { get; set; }
        public T Decendannt { get; set; }
        public int Level { get; set; }
    }
}
