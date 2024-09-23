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
    public class CountrieConfigration : IEntityTypeConfiguration<Countrie>
    {
        public void Configure(EntityTypeBuilder<Countrie> builder)
        {
            builder.ToTable("Countries");
            builder.HasKey(x => x.id);
            builder.Property(x => x.CountryName).IsRequired().HasMaxLength(100);

        }
    }
}
