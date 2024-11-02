using Entites.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(500);

            builder.Property(x => x.Price)
               .IsRequired();

            builder.Property(x => x.Description)
               .IsRequired()
               .HasMaxLength(5000);

            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            builder.HasIndex(x => x.Name);

            builder.HasIndex(x => new { x.Name, x.IsDeleted })
                .IsUnique();
        }
    }
}
