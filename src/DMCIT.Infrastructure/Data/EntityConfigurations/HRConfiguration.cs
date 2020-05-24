using DMCIT.Core.Entities.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMCIT.Infrastructure.Data.EntityConfigurations
{
    public class HRConfiguration :
        IModuleConfiguration,
        IEntityTypeConfiguration<Department>,
        IEntityTypeConfiguration<DepartmentRelation>,
        IEntityTypeConfiguration<Employee>
    {
        public void ConfigureAll(ModelBuilder model)
        {
            model.ApplyConfiguration<Department>(this);
            model.ApplyConfiguration<DepartmentRelation>(this);
            model.ApplyConfiguration<Employee>(this);
        }
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            new BaseVSConfiguration<Employee>(builder);
            builder.HasOne(u => u.Department).WithMany(u => u.Employees).HasForeignKey(u => u.DepartmentId);
            builder.HasOne(U => U.AppUser).WithOne(u => u.Employee).HasForeignKey<AppUser>(u => u.EmployeeId);
            builder.HasIndex(u => u.Code);
        }

        public void Configure(EntityTypeBuilder<DepartmentRelation> builder)
        {
            new VSTreeRelationConfiguration<Department, DepartmentRelation>(builder);
        }

        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(u => u.Manager).WithMany().HasForeignKey(u => u.ManagerId);
            var vsConf = new BaseVSConfiguration<Department>();
            vsConf.Configure(builder);
        }
    }
}
