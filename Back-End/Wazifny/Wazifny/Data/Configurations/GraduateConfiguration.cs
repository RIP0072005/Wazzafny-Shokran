using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wazifny.Models;

namespace Wazifny.Data.Configurations
{
    public class GraduateConfiguration : IEntityTypeConfiguration<Graduate>
    {
        public void Configure(EntityTypeBuilder<Graduate> builder)
        {
            builder.ToTable("Graduates"); 
            builder.Property(g => g.Education).HasMaxLength(500);
        }
    }
}
