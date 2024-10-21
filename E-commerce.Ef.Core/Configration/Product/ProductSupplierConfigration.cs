using E_commerce.Ef.Core.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Configration.Product
{
    public class ProductSupplierConfigration: IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {
            builder.ToTable("ProductSupplier");
            builder.HasKey(x => x.id);
                
            builder.HasOne(x => x.Product)
               .WithMany(p => p.ProductSuppliers)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Cascade); 

        builder.HasOne(x => x.Supplier)
               .WithMany(s => s.ProductSuppliers)
               .HasForeignKey(x => x.SupplierId)
               .OnDelete(DeleteBehavior.Cascade);

       
        builder.Property(x => x.ProductId)
               .IsRequired();

        builder.Property(x => x.SupplierId)
               .IsRequired();
        }


    }
}
