using DMCIT.Core.Entities.SupportRequests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMCIT.Infrastructure.Data.EntityConfigurations
{
    public class SupportRequestConfiguration :
        IModuleConfiguration,
        IEntityTypeConfiguration<SupportRequest>,
        IEntityTypeConfiguration<SupportAssistant>
    {
        public void Configure(EntityTypeBuilder<SupportRequest> builder)
        {
            new BaseVSConfiguration<SupportRequest>(builder);
            builder.HasOne(u => u.Requester)
                .WithMany().HasForeignKey(u => u.RequesterId);
            builder.HasOne(u => u.AssignedBy)
                .WithMany().HasForeignKey(u => u.AssignedById);
            builder.HasOne(u => u.AssignedTo)
                .WithMany().HasForeignKey(u => u.AssignedToId);
            builder.HasOne(u => u.Post)
                .WithOne().HasForeignKey<SupportRequest>(u => u.PostId);
        }

        public void Configure(EntityTypeBuilder<SupportAssistant> builder)
        {
            new BaseVSConfiguration<SupportAssistant>(builder);
            builder.HasOne(u => u.SupportRequest).WithMany(u => u.SupportAssistants).HasForeignKey(u => u.SupportRequestId);
            builder.HasOne(u => u.Assistant)
                .WithMany().HasForeignKey(u => u.AssistantId).OnDelete(DeleteBehavior.Restrict);
        }

        public void ConfigureAll(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<SupportRequest>());
            Configure(modelBuilder.Entity<SupportAssistant>());
        }
    }
}
