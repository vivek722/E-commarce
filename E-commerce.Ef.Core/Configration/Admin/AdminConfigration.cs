using E_Commrece.Domain.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Configration.Admin
{
    public class AdminConfigration : IEntityTypeConfiguration<AdminModel>
    {
        public void Configure(EntityTypeBuilder<AdminModel> builder)
        {
            builder.ToTable("Admin");
            builder.HasKey(x => x.id);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.Street).HasMaxLength(100);
            builder.Property(x => x.City).HasMaxLength(100);
            builder.Property(x => x.State).HasMaxLength(100);
            builder.Property(x => x.ZipCode).HasMaxLength(10);

            builder.HasOne(x => x.Role)
             .WithMany(x => x.AdminModel)
             .HasForeignKey(x => x.RoleId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
