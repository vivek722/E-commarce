using E_commerce.Ef.Core.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Configration.User
{
    public class AddressConfigration : IEntityTypeConfiguration<Addresse>
    {
        public void Configure(EntityTypeBuilder<Addresse> builder)
        {
            builder.ToTable("Addresses");
            builder.HasKey(x => x.id);
            builder.Property(x => x.Street).IsRequired().HasMaxLength(255);
            builder.Property(x => x.City).IsRequired().HasMaxLength(100);
            builder.Property(x => x.State).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ZipCode).IsRequired().HasMaxLength(10);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Addresse)
                .HasForeignKey(x => x.Userid)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
