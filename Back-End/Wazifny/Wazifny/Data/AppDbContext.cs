using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wazifny.Models;
namespace Wazifny.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Graduate> Graduates { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=HESHAM\\SQLEXPRESS;database=Wazifny;trusted_connection=true;trust server certificate = true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
