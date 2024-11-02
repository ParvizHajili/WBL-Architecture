using Core.Constants;
using Entites.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(x => x.Name);

            builder.HasIndex(x=> new {x.Name,x.IsDeleted})
                .IsUnique()
                .HasDatabaseName("idx_Category_Name_Deleted");
        }
    }
}
