using E_commerce.Ef.Core.Product;
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
    public class DiscountConfigration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.ToTable("Discount");
            builder.HasKey(x => x.id);
            builder.Property(x => x.DiscountAmount);
            builder.Property(x => x.StartDate);
            builder.Property(x => x.EndDate);

            builder.HasOne(x => x.product).
                WithMany(x => x.Discount).
                HasForeignKey(x => x.ProductId).
                OnDelete(DeleteBehavior.Cascade);

        }
    }
}
