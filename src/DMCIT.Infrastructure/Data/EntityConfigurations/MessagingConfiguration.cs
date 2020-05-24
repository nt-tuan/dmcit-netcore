using DMCIT.Core.Entities.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DMCIT.Infrastructure.Data.EntityConfigurations
{
    class MessagingConfiguration :
IModuleConfiguration, IEntityTypeConfiguration<MessageReceiverGroupMessageReceiver>,
        IEntityTypeConfiguration<ReceiverProvider>,
        IEntityTypeConfiguration<MessageServiceProvider>,
        IEntityTypeConfiguration<MessageReceiver>,
        IEntityTypeConfiguration<MessageReceiverGroup>,
        IEntityTypeConfiguration<AutoMessageConfigProvider>,
        IEntityTypeConfiguration<AutoMessageConfigMessageReceiverGroup>,
        IEntityTypeConfiguration<AutoMessageConfigMessageReceiver>,
        IEntityTypeConfiguration<AutoMessageConfig>,
        IEntityTypeConfiguration<ReceiverCategory>,
        IEntityTypeConfiguration<MessageSource>
    {
        public void Configure(EntityTypeBuilder<MessageReceiverGroupMessageReceiver> builder)
        {
            var vsConf = new BaseVSConfiguration<MessageReceiverGroupMessageReceiver>();
            vsConf.Configure(builder);
        }

        public void Configure(EntityTypeBuilder<ReceiverProvider> builder)
        {
            var vsConf = new BaseVSConfiguration<ReceiverProvider>();
            vsConf.Configure(builder);
        }

        public void Configure(EntityTypeBuilder<MessageServiceProvider> builder)
        {
            var vsConf = new BaseVSConfiguration<MessageServiceProvider>();
            vsConf.Configure(builder);
            var now = DateTime.Now;
            builder.HasData(new[]{
                new MessageServiceProvider
                {
                    Id = 1,
                    Name = "Dịch vụ nhắn tin thương hiệu của Viettel",
                    AddressRegex = @"(84)+([0-9]{9})\b",
                    Code = "viettel",
                    Module = "DMCIT.Infrastructure.Providers.Test",
                    AddressLabel = "Viettel SMS Brandname",
                    DateCreated = now,
                    DateEffective = now
                },
                new MessageServiceProvider
                {
                    Id = 2,
                    Name = "Dịch vụ nhắn tin giá rẻ Netco",
                    AddressRegex = @"(09|01[2|6|8|9])+([0-9]{8})\b",
                    Module = "DMCIT.Infrastructure.Providers.Test",
                    Code ="netco",
                    AddressLabel = "Netco SMS",
                    DateCreated = now,
                    DateEffective = now
                },
                new MessageServiceProvider
                {
                    Id = 3,
                    Name = "Dịch vụ nhắn tin qua Zalo",
                    AddressRegex = "(.*?)",
                    Module = "DMCIT.Infrastructure.Providers.Test",
                    Code = "zalo",
                    AddressLabel = "Zalo",
                    DateCreated = now,
                    DateEffective = now
                }
                });
        }

        public void Configure(EntityTypeBuilder<MessageReceiver> builder)
        {
            var vsConf = new BaseVSConfiguration<MessageReceiver>();
            vsConf.Configure(builder);
        }

        public void Configure(EntityTypeBuilder<MessageReceiverGroup> builder)
        {
            new BaseVSConfiguration<MessageReceiverGroup>(builder);
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigProvider> builder)
        {
            new BaseVSConfiguration<AutoMessageConfigProvider>(builder);
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigMessageReceiver> builder)
        {
            new BaseVSConfiguration<AutoMessageConfigMessageReceiver>(builder);
        }

        public void Configure(EntityTypeBuilder<MessageSource> builder)
        {
            new BaseVSConfiguration<MessageSource>(builder);
        }

        public void Configure(EntityTypeBuilder<ReceiverCategory> builder)
        {
            new BaseVSConfiguration<ReceiverCategory>(builder);
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfig> builder)
        {
            new BaseVSConfiguration<AutoMessageConfig>(builder);
        }

        public void Configure(EntityTypeBuilder<AutoMessageConfigMessageReceiverGroup> builder)
        {
            new BaseVSConfiguration<AutoMessageConfigMessageReceiverGroup>(builder);
        }

        public void ConfigureAll(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<AutoMessageConfig>(this);
            modelBuilder.ApplyConfiguration<AutoMessageConfigMessageReceiverGroup>(this);
            modelBuilder.ApplyConfiguration<AutoMessageConfigProvider>(this);
            modelBuilder.ApplyConfiguration<MessageReceiverGroup>(this);
            modelBuilder.ApplyConfiguration<ReceiverCategory>(this);
            modelBuilder.ApplyConfiguration<ReceiverProvider>(this);
            modelBuilder.ApplyConfiguration<MessageSource>(this);

            modelBuilder.ApplyConfiguration<MessageServiceProvider>(this);
            modelBuilder.ApplyConfiguration<MessageReceiverGroupMessageReceiver>(this);
            modelBuilder.ApplyConfiguration<ReceiverProvider>(this);
            modelBuilder.ApplyConfiguration<MessageReceiver>(this);
            modelBuilder.Entity<SentMessage>()
                .HasOne(u => u.MessageBatch).WithMany(u => u.SentMessages)
                .HasForeignKey(u => u.MessageBatchId);

            modelBuilder.ApplyConfiguration<MessageReceiver>(this);
        }
    }
}
