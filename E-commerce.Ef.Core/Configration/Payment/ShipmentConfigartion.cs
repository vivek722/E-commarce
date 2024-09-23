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
    public class ShipmentConfigartion : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("Shipments");
            builder.HasKey(x => x.id);
            builder.Property(x => x.ShipmentDate);

            builder.HasOne(x => x.Orders)
                .WithMany(x => x.Shipment)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Shippers)
                .WithMany(x => x.Shipment)
                .HasForeignKey(x => x.ShipperId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
