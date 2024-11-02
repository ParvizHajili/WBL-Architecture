using Core.Constants;
using Entites.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class PreferenceConfiguration : IEntityTypeConfiguration<Preference>
    {
        public void Configure(EntityTypeBuilder<Preference> builder)
        {
            builder.ToTable("Preferences");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE);

            builder.Property(x => x.Title)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(3000);

            builder.Property(x => x.IconUrl)
                .IsRequired()
                .HasMaxLength(250);

            builder.HasIndex(x => new { x.Title, x.IsDeleted })
                .IsUnique();
        }
    }
}
