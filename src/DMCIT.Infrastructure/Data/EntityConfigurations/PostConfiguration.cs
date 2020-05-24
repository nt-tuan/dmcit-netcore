using DMCIT.Core.Entities.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DMCIT.Infrastructure.Data.EntityConfigurations
{
    public class PostConfiguration :
        IModuleConfiguration,
        IEntityTypeConfiguration<Post>,
        IEntityTypeConfiguration<PostCategory>,
        IEntityTypeConfiguration<PostCategoryRelation>,
        IEntityTypeConfiguration<PostComment>,
        IEntityTypeConfiguration<PostCommentRelation>,
        IEntityTypeConfiguration<PostTag>,
        IEntityTypeConfiguration<PostAccessUser>
    {
        public void ConfigureAll(ModelBuilder builder)
        {
            builder.ApplyConfiguration<Post>(this);
            builder.ApplyConfiguration<PostCategory>(this);
            builder.ApplyConfiguration<PostCategoryRelation>(this);
            builder.ApplyConfiguration<PostComment>(this);
            builder.ApplyConfiguration<PostCommentRelation>(this);
            builder.ApplyConfiguration<PostTag>(this);
            builder.ApplyConfiguration<PostAccessUser>(this);
        }
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            new BaseVSConfiguration<Post>(builder);
            builder.HasOne(u => u.Category)
                .WithMany(u => u.Posts).HasForeignKey(u => u.CategoryId);
        }

        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            new VSTreeNodeConfiguration<PostCategory, PostCategoryRelation>(builder);
        }

        public void Configure(EntityTypeBuilder<PostCategoryRelation> builder)
        {
            new VSTreeRelationConfiguration<PostCategory, PostCategoryRelation>(builder);
        }

        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            new BaseVSConfiguration<PostComment>(builder);
            builder.HasOne(u => u.Post).WithMany(u => u.Comments).HasForeignKey(u => u.PostId);
        }

        public void Configure(EntityTypeBuilder<PostCommentRelation> builder)
        {
            new VSTreeRelationConfiguration<PostComment, PostCommentRelation>(builder);
        }

        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasOne(u => u.Tag)
    .WithMany().HasForeignKey(u => u.TagId);
            builder.HasOne(u => u.Post)
                .WithMany().HasForeignKey(u => u.PostId);
        }

        public void Configure(EntityTypeBuilder<PostAccessUser> builder)
        {
            builder.HasOne(u => u.Post).WithMany(u => u.PostAccessUsers).HasForeignKey(u => u.PostId);
            builder.HasOne(u => u.AppUser)
                .WithMany().HasForeignKey(u => u.AppUserId);
        }
    }
}
