using E_commerce.Ef.Core.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Ef.Core.Configration.Employee
{
    public class ProjectConfigration : IEntityTypeConfiguration<Projects>
    {
        public void Configure(EntityTypeBuilder<Projects> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(x=>x.id);
            builder.Property(x=>x.ProjectName).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.StartDated);
            builder.Property(x=>x.EndDate);
        }
    }
}
