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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Quantity).IsRequired();

            builder.HasOne(x => x.Order).WithMany(x => x.OrderDetail).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.product).WithMany(x => x.OrderDetail).HasForeignKey(x => x.productId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
