using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.DataAccess.Configuration
{
    public class UserConfiguration : EntityConfiguration<User>
    {
        protected override void ConfigureRules(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Country).HasMaxLength(40).IsRequired();
            builder.Property(x => x.City).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.FirstName);
            builder.HasIndex(x => x.LastName);

            builder.HasMany(x => x.UseCases)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.UseCaseLogs)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

        }
    }
}
