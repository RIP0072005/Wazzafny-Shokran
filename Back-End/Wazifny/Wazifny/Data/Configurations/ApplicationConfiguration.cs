using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wazifny.Models;
namespace Wazifny.Data.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(a => a.Id);

           
            builder.HasOne(a => a.Job)
                   .WithMany(j => j.Applications)
                   .HasForeignKey(a => a.JobId)
                   .OnDelete(DeleteBehavior.NoAction); 

          
            builder.HasOne(a => a.Graduate)
                   .WithMany(g => g.Applications)
                   .HasForeignKey(a => a.GraduateId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
