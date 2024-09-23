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
    public class ShippersConfigartion : IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> builder)
        {
            builder.ToTable("Shippers");
            builder.HasKey(x => x.id);
            builder.Property(x => x.ShipperName).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Phone).HasMaxLength(20);
        }
    }
}
