using E_commerce.Ef.Core.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Configration.Payment
{
    public class WarehouseConfigartion : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.ToTable("Warehouses");
            builder.HasKey(x => x.id);
            builder.Property(x => x.WarehouseName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Location).HasMaxLength(225);
        }
    }
}
