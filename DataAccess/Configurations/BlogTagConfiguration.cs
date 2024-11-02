using Core.Constants;
using Entites.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>
    {
        public void Configure(EntityTypeBuilder<BlogTag> builder)
        {
            builder.ToTable("BlogTags");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE);

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.BlogTags)
                .HasForeignKey(x => x.BlogId);

            builder.HasOne(x => x.Tag)
               .WithMany(x => x.BlogTags)
               .HasForeignKey(x => x.TagId);
        }
    }
}
