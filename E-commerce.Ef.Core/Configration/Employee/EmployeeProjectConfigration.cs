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
    public class EmployeeProjectConfigration : IEntityTypeConfiguration<EmployeeProject>
    {
        public void Configure(EntityTypeBuilder<EmployeeProject> builder)
        {
            builder.ToTable("EmployeeProjects");
            builder.HasKey(x => x.id);

            builder.HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeProject)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.Projects)
                .WithMany(x => x.EmployeeProject)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
