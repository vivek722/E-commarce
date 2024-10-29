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
    public class OrderDetailConfigration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => x.id);
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(x => x.Order).WithOne(x => x.OrderDetail).HasForeignKey<OrderDetail>(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.product).WithOne(x => x.OrderDetail).HasForeignKey<OrderDetail>(x => x.productId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
