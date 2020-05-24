using DMCIT.Core.Entities;
using DMCIT.Core.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMCIT.Infrastructure.Data.EntityConfigurations
{
    class CoreConfiguration :
        IModuleConfiguration,
        IEntityTypeConfiguration<Person>,
        IEntityTypeConfiguration<Business>,
        IEntityTypeConfiguration<Setting>,
        IEntityTypeConfiguration<AccountingPeriod>,
        IEntityTypeConfiguration<Tag>
    {
        public void ConfigureAll(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Person>(this);
            modelBuilder.ApplyConfiguration<Business>(this);
            modelBuilder.ApplyConfiguration<Setting>(this);
            modelBuilder.ApplyConfiguration<AccountingPeriod>(this);
            modelBuilder.ApplyConfiguration<Tag>(this);
            var hrConf = new HRConfiguration();
            hrConf.ConfigureAll(modelBuilder);
        }
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            var vsConf = new BaseVSConfiguration<Person>();
            vsConf.Configure(builder);
        }
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            var vsConf = new BaseVSConfiguration<Business>();
            vsConf.Configure(builder);
        }

        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            new BaseVSConfiguration<Setting>(builder);
        }

        public void Configure(EntityTypeBuilder<AccountingPeriod> builder)
        {
            new BaseVSConfiguration<AccountingPeriod>(builder);
        }

        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(u => u.Value);
        }
    }

}
