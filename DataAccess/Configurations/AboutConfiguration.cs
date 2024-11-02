using Core.Constants;
using Entites.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE);

            builder.Property(x => x.Title)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Description)
               .HasMaxLength(5000)
               .IsRequired();

            builder.Property(x => x.ImageUrl)
               .HasMaxLength(150)
               .IsRequired();
        }
    }
}
