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
    public class PaymentConfigration : IEntityTypeConfiguration<Payments>
    {
        public void Configure(EntityTypeBuilder<Payments> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(x => x.id);
            builder.Property(x => x.PaymentAmount);

            builder.HasOne(x=>x.invoices)
                .WithMany(x=>x.Payments)
                .HasForeignKey(x=>x.InvoicesId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
