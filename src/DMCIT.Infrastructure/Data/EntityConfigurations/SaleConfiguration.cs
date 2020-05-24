using DMCIT.Core.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DMCIT.Infrastructure.Data.EntityConfigurations
{
    class SaleConfiguration :
        IModuleConfiguration,
        IEntityTypeConfiguration<Customer>,
        IEntityTypeConfiguration<Distributor>

    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            new BaseVSConfiguration<Customer>(builder);
            builder.HasIndex(u => u.Code);
            builder.HasOne(u => u.AppUser).WithOne(u => u.Customer).HasForeignKey<Core.Entities.Core.AppUser>(u => u.CustomerId);
        }

        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            new BaseVSConfiguration<Distributor>(builder);
            var now = DateTime.Now;
            builder.HasIndex(u => u.Code);
            builder.HasData(new Distributor[] {
                new Distributor
                {
                    Id = 1,
                    Code = "DT",
                    Name = "Chi nhánh Đồng Tháp",
                    DateCreated = now,
                    DateEffective = now

                },new Distributor
                {
                    Id = 2,
                    Code = "CT",
                    Name = "Chi nhánh Cần Thơ",
                    DateCreated = now,
                    DateEffective = now
                },new Distributor{
                    Id = 3,
                    Code = "AG",
                    Name = "Chi nhánh An Giang",
                    DateCreated = now,
                    DateEffective = now
                },new Distributor{
                    Id = 4,
                    Code = "TP",
                    Name = "Chi nhánh Hồ Chí Minh",
                    DateCreated = now,
                    DateEffective = now
                },new Distributor{
                    Id = 5,
                    Code = "MD",
                    Name = "Chi nhánh Miền Đông",
                    DateCreated = now,
                    DateEffective = now
                },new Distributor{
                    Id = 6,
                    Code = "TN",
                    Name = "Chi nhánh Tây Nguyên",
                    DateCreated = now,
                    DateEffective = now
                },new Distributor{
                    Id = 7,
                    Code = "DN",
                    Name = "Chi nhánh Đà Nẵng",
                    DateCreated = now,
                    DateEffective = now
                },new Distributor{
                    Id = 8,
                    Code = "VI",
                    Name = "Chi nhánh Vinh",
                    DateCreated = now,
                    DateEffective = now
                },new Distributor{
                    Id = 9,
                    Code = "TH",
                    Name = "Chi nhánh Thái Nguyên",
                    DateCreated = now,
                    DateEffective = now
                },new Distributor{
                    Id = 10,
                    Code = "HN",
                    Name = "Chi nhánh Hà Nội",
                    DateCreated = now,
                    DateEffective = now
                },new Distributor{
                    Id = 11,
                    Code = "HD",
                    Name = "Chi nhánh Hải Dương",
                    DateCreated = now,
                    DateEffective = now
                }
            });
        }

        public void ConfigureAll(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Customer>(this);
            modelBuilder.ApplyConfiguration<Distributor>(this);
        }
    }
}
