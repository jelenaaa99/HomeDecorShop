using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.DataAccess.Configuration
{
    public class OrderConfiguration : EntityConfiguration<Order>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Country).HasMaxLength(40).IsRequired();
            builder.Property(x => x.City).HasMaxLength(40).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();

            builder.HasIndex(x => x.Country);
            builder.HasIndex(x => x.City);

            builder.HasMany(x => x.OrderLines)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
