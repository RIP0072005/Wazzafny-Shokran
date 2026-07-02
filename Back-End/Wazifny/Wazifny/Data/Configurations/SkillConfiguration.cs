using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Wazifny.Models;

namespace Wazifny.Data.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(s => s.Graduates)
                   .WithMany(g => g.Skills)
                   .UsingEntity(j => j.ToTable("GraduateSkills"));

            builder.HasMany(s => s.Jobs)
                   .WithMany(j => j.RequiredSkills)
                   .UsingEntity(j => j.ToTable("JobRequiredSkills"));
        }
    }
}
