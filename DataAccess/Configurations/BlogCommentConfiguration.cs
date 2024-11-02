using Core.Constants;
using Entites.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class BlogCommentConfiguration : IEntityTypeConfiguration<BlogComment>
    {
        public void Configure(EntityTypeBuilder<BlogComment> builder)
        {
            builder.ToTable("BlogComments");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE);

            builder.Property(x => x.Text)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.ParentId)
                .IsRequired(false);

            builder.Property(x => x.BlogId)
                .IsRequired(true);

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.BlogComments)
                .HasForeignKey(x => x.BlogId);
        }
    }
}
