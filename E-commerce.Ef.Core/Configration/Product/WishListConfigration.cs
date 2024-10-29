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
    public class WishListConfigration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.ToTable("WishList");
            builder.HasKey(x => x.id);
            builder.Property(x => x.AddedDate).IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.Wishlist).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.User).WithOne(x => x.Wishlist).HasForeignKey<Wishlist>(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
