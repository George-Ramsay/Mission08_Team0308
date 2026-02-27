using Microsoft.EntityFrameworkCore;
using Mission08_Assignment.Models;

namespace Mission08_Assignment.Data
{
    // This connects your models to the database
    public class QuadrantsContext : DbContext
    {
        public QuadrantsContext(DbContextOptions<QuadrantsContext> options)
            : base(options)
        {
        }

        // Represents TaskItem table
        public DbSet<TaskItem> TaskItems { get; set; }

        // Represents Category table
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map to actual table names in the database
            modelBuilder.Entity<TaskItem>().ToTable("TaskItem");
            modelBuilder.Entity<Category>().ToTable("Category");

            // Seed Category table so dropdown is pre-populated
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );
        }
    }
}