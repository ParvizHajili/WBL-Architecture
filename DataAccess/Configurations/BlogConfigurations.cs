using Core.Constants;
using Entites.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class BlogConfigurations : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE);

            builder.Property(x => x.Title)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Description)
               .HasMaxLength(5000)
               .IsRequired();

            builder.Property(x => x.ImageUrl)
               .HasMaxLength(250)
               .IsRequired();


            builder.HasIndex(x => x.Title);

            builder.HasIndex(x => new { x.Title, x.IsDeleted })
                .IsUnique();
        }
    }
}
