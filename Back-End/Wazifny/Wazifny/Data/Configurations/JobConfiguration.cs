using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wazifny.Models;

namespace Wazifny.Data.Configurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.HasKey(j => j.Id);
             builder.Property(j => j.Title).IsRequired().HasMaxLength(200); 
         builder.Property(j => j.Salary).HasColumnType("decimal(18,2)"); 

        
        builder.HasOne(j => j.Employer)
               .WithMany(e => e.Jobs)
               .HasForeignKey(j => j.EmployerId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
