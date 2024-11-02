using Core.Constants;
using Entites.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.ToTable("Testimonials");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE);


            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.ImageUrl)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Message)
                .IsRequired()
                .HasMaxLength(3000);

            builder.HasOne(x => x.Position)
                .WithMany(x => x.Testimonials)
                .HasForeignKey(x => x.PositonId);

            builder.Property(x => x.PositonId)
               .IsRequired();

            builder.HasIndex(x => x.FirstName)
                ;

            builder.HasIndex(x => new { x.FirstName, x.IsDeleted })
                .IsUnique();
        }
    }
}
