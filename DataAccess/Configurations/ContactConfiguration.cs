using Core.Constants;
using Entites.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Phone)
               .IsRequired()
               .HasMaxLength(15);

            builder.Property(x => x.Subject)
               .IsRequired()
               .HasMaxLength(500);

            builder.Property(x => x.Message)
               .IsRequired()
               .HasMaxLength(3000);

            builder.Property(x => x.IsContacted)
                .HasDefaultValue(false);

            builder.HasIndex(x => x.Email);

            builder.HasIndex(x => new { x.Email, x.IsDeleted })
                .IsUnique();
        }
    }
}
