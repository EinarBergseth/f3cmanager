
using DataAccess.Migrations;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply model configuration (indexes, delete behaviour ...):
            modelBuilder.ApplyConfiguration(new Manouver.ManouverConfiguration());
          
            // Apply data seeds:
            modelBuilder.Seed();

            modelBuilder.SetDateTimeKind();
        }

        // Database sets (tables)
        public DbSet<Manouver> Manouvers { get; set; }

    }
}