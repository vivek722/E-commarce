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
    internal class SupplierPageConfigration : IEntityTypeConfiguration<SupplierPageSetting>
    {
        public void Configure(EntityTypeBuilder<SupplierPageSetting> builder)
        {
            builder.ToTable("Supplier-Page-setting");
            builder.HasKey(x => x.id);
            builder.Property(x => x.PageName).IsRequired();
            builder.Property(x => x.IsPageActive);
            builder.Property(x => x.IsLoderActive);
            builder.Property(x => x.IsTosterActive);
            builder.Property(x => x.IsDeleteDialogActive);
        }
    }
}
