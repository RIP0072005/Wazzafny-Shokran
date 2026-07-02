using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wazifny.Models;

namespace Wazifny.Data.Configurations
{
    public class EmployerConfiguration : IEntityTypeConfiguration<Employer>
    {
        public void Configure(EntityTypeBuilder<Employer> builder)
        {
            builder.ToTable("Employers"); 
             builder.Property(e => e.CompanyName).IsRequired().HasMaxLength(200); 
    }
    }
}
