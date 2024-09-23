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
    public class OrderConfigration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.id);
            builder.Property(x => x.OrderDate).IsRequired();

            builder.HasOne(x => x.customer).WithMany(x => x.orders).HasForeignKey(x => x.customerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
