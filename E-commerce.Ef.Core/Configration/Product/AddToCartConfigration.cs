using E_Commrece.Domain.ProductData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Configration.Product
{
    public class AddToCartConfigration : IEntityTypeConfiguration<AddToCart>
    {
        public void Configure(EntityTypeBuilder<AddToCart> builder)
        {
            builder.ToTable("AddToCart");
            builder.HasKey(x => x.id);
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.AddedDate).IsRequired();
            builder.Property(x => x.LastUpdated);

            builder.HasOne(x => x.Product).WithMany(x => x.AddToCart).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.User).WithOne(x => x.AddToCart).HasForeignKey<AddToCart>(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
