using E_commerce.Ef.Core.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_commerce.Ef.Core.Configration.User
{
    public class CitiesConfiguration : IEntityTypeConfiguration<Citie>
    {
        public void Configure(EntityTypeBuilder<Citie> builder)
        {
            builder.ToTable("Cities");

            builder.HasKey(x => x.id); 

            builder.Property(x => x.CityName)
                   .IsRequired() 
                   .HasMaxLength(100); 

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.NoAction); 
        }
    }
}
