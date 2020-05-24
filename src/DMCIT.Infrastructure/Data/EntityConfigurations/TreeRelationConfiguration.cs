using DMCIT.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMCIT.Infrastructure.Data.EntityConfigurations
{
    public class TreeRelationConfiguration<ITree, IRelation> : IEntityTypeConfiguration<IRelation>
        where IRelation : TreeRelationEntity<ITree, IRelation>
        where ITree : TreeNodeEntity<ITree, IRelation>
    {
        public void Configure(EntityTypeBuilder<IRelation> builder)
        {
            builder.Ignore(u => u.Id);
            builder.HasOne(u => u.Decendannt).WithMany(u => u.Decendants).HasForeignKey(u => u.DecendanntId);
            builder.HasOne(u => u.Ancestor).WithMany(u => u.Ancestors).HasForeignKey(u => u.AncestorId);
            builder.HasKey(u => new { u.DecendanntId, u.AncestorId });
            builder.Ignore(u => u.Id);
        }
    }

    public class VSTreeNodeConfiguration<ITree, IRelation> : IEntityTypeConfiguration<ITree>
        where IRelation : VSTreeRelationEntity<ITree, IRelation>
        where ITree : VSTreeNodeEntity<ITree, IRelation>
    {
        public VSTreeNodeConfiguration(EntityTypeBuilder<ITree> builder)
        {
            Configure(builder);
        }
        public void Configure(EntityTypeBuilder<ITree> builder)
        {
            new BaseVSConfiguration<ITree>(builder);
            builder.HasOne(u => u.Parent).WithMany(u => u.Children).HasForeignKey(u => u.ParentId);
        }
    }

    public class VSTreeRelationConfiguration<ITree, IRelation> : IEntityTypeConfiguration<IRelation>
        where IRelation : VSTreeRelationEntity<ITree, IRelation>
        where ITree : VSTreeNodeEntity<ITree, IRelation>
    {
        public VSTreeRelationConfiguration(EntityTypeBuilder<IRelation> builder)
        {
            Configure(builder);
        }
        public void Configure(EntityTypeBuilder<IRelation> builder)
        {
            new BaseVSConfiguration<IRelation>(builder);
            builder.HasOne(u => u.Decendannt).WithMany(u => u.Decendants).HasForeignKey(u => u.DecendanntId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(u => u.Ancestor).WithMany(u => u.Ancestors).HasForeignKey(u => u.AncestorId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
