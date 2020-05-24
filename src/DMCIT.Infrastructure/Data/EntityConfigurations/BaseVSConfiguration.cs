using DMCIT.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMCIT.Infrastructure.Data.EntityConfigurations
{
    public class BaseVSConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseVersionControlEntity<T>
    {
        public BaseVSConfiguration()
        {

        }

        public BaseVSConfiguration(EntityTypeBuilder<T> builder)
        {
            Configure(builder);
        }
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasIndex(u => u.DateEffective);
            builder.HasIndex(u => u.DateEnd);
            builder.HasOne(u => u.Origin).WithMany(u => u.Versions).HasForeignKey(u => u.OriginId);
            builder.HasOne(u => u.CreatedBy).WithMany().HasForeignKey(u => u.CreatedById);
            builder.HasOne(u => u.RemovedBy).WithMany().HasForeignKey(u => u.RemovedById);
            builder.Ignore(u => u.LastModifiedBy);
            builder.Ignore(u => u.LastModifiedById);
            builder.Ignore(u => u.LastModifiedTime);
        }
    }
}
