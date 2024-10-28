using E_commerce.Ef.Core.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Configration.Payment
{
    public class InventoryConfigration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.id);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.ProductId);

            builder.HasOne(x => x.Warehouse)
                .WithMany(x => x.Inventory)
                .HasForeignKey(x => x.WarehouseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
