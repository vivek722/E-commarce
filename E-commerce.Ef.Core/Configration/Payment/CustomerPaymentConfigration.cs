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
    public class CustomerPaymentConfigration : IEntityTypeConfiguration<CustomerPayment>
    {
        public void Configure(EntityTypeBuilder<CustomerPayment> builder)
        {
            builder.ToTable("CustomerPayments");
            builder.HasKey(x => x.id);

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.CustomerPayment)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.paymentMethod)
                .WithMany(x => x.CustomerPayment)
                .HasForeignKey(x => x.paymentMethodId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
