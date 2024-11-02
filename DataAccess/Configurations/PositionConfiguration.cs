using Core.Constants;
using Entites.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(x => new { x.Name, x.IsDeleted })
                .IsUnique();
        }
    }
}
