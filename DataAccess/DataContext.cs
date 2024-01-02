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

            // Apply model configuration (indexes, delete behaviour, relations ...):
            modelBuilder.ApplyConfiguration(new Manouver.ManouverConfiguration());
            modelBuilder.ApplyConfiguration(new Event.EventConfiguration());
            modelBuilder.ApplyConfiguration(new User.UserConfiguration());

            // Apply data seeds:
            modelBuilder.Seed();

            modelBuilder.SetDateTimeKind();
        }

        // Database sets (tables)
        
        public DbSet<Event> Events { get; set; }
        public DbSet<Manouver> Manouvers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}