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
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValues.DEFAULT_PRIMARY_KEY_INCREMENT_VALUE);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.InstagramAdress)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(x => x.Position)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.PositionId);

            builder.Property(x => x.PositionId)
               .IsRequired();

            builder.HasIndex(x => x.FirstName)
                ;

            builder.HasIndex(x => new { x.FirstName, x.IsDeleted })
                .IsUnique();
        }
    }
}
