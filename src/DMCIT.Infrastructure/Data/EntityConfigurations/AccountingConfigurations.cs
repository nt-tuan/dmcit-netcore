using DMCIT.Core.Entities.Accounting;
using DMCIT.Core.Entities.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMCIT.Infrastructure.Data.EntityConfigurations
{
    class AccountingConfigurations :
        IModuleConfiguration,
        IEntityTypeConfiguration<CustomerAR>, IEntityTypeConfiguration<CustomerPayment>,
        IEntityTypeConfiguration<Diary131>,
        IEntityTypeConfiguration<CustomerARNow>
    {
        public void ConfigureAll(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<CustomerAR>(this);
            modelBuilder.ApplyConfiguration<CustomerPayment>(this);
            modelBuilder.ApplyConfiguration<Diary131>(this);
            modelBuilder.ApplyConfiguration<CustomerARNow>(this);

            modelBuilder.Query<CalculatedCustomerLiabilityQuery>();
            modelBuilder.Query<CalculatedCustomerPayment>();
        }
        public void Configure(EntityTypeBuilder<CustomerAR> builder)
        {
            builder.HasKey(u => new
            {
                u.CustomerCode,
                u.DistributorCode,
                u.DispatchAccountingPeriodId
            });
        }

        public void Configure(EntityTypeBuilder<CustomerPayment> builder)
        {
            builder.HasKey(u => new { u.CustomerCode, u.DistributorCode, u.ReceiptDate });
        }

        public void Configure(EntityTypeBuilder<Diary131> builder)
        {
            builder.HasIndex(u => new { u.ReceiptDate });
            builder.HasKey(u => new { u.Id, u.Source, u.DistributorCode });
        }

        public void Configure(EntityTypeBuilder<CustomerARNow> builder)
        {
            builder.HasKey(u => new { u.CustomerCode, u.DistributorCode });
        }
    }
}
