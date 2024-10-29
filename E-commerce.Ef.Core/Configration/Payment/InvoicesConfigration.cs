using E_commerce.Ef.Core.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Configration.Payment
{
    public class InvoicesConfigration : IEntityTypeConfiguration<Invoices>
    {
        public void Configure(EntityTypeBuilder<Invoices> builder)
        {
            builder.ToTable("Invoices");
            builder.HasKey(x => x.id);
            builder.Property(x => x.InvoiceDate);
            builder.Property(x => x.TotalAmount);
            builder.HasOne(x=>x.orders)
                .WithOne(x => x.Invoices)
                .HasForeignKey<Invoices>(x=>x.orderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
