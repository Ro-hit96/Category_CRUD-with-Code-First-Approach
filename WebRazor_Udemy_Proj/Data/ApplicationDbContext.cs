using Microsoft.EntityFrameworkCore;
using WebRazor_Udemy_Proj.Model;

namespace WebRazor_Udemy_Proj.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Mobile", DisplayOrder = 12 },
                new Category { Id = 3, Name = "Laptop", DisplayOrder = 12 }
                );
        }

    }
}
