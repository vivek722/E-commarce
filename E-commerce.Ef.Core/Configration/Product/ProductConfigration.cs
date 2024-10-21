using Microsoft.EntityFrameworkCore;
using E_commerce.Ef.Core.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Ef.Core.Configration.Product
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.id);

            builder.Property(x => x.ProductName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Price)
                   .IsRequired()
                   .HasColumnType("decimal(10, 2)");
        }
    }

}
