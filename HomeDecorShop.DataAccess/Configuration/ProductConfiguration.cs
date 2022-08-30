using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjekatASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatASP.DataAccess.Configuration
{
    public class ProductConfiguration : EntityConfiguration<Product>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Name).HasMaxLength(70).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Img).IsRequired();

            builder.HasMany(x => x.OrderLines)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

        }
    }
}
