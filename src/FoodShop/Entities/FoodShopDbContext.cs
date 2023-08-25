using Microsoft.EntityFrameworkCore;

namespace FoodShop.Entities
{
    public class FoodShopDbContext : DbContext
    {
        private string _connectionString =
            "Data Source=hubertpc;" +
            "Initial Catalog=FoodShopDB;" +
            "Integrated Security=SSPI;" +
            "TrustServerCertificate=True; ";
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Category>()
                .Property(r => r.Name)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
