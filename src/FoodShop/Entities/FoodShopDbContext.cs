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
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer > Customers { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Category>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(r => r.OrderStatus)
                .IsRequired()
                .HasConversion<int>();

            modelBuilder.Entity<Customer>()
                .Property(r => r.Phone)
                .IsRequired()
                .HasMaxLength(12);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(r => r.Product)
                .WithMany(r => r.OrderProducts)
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(r => r.Order)
                .WithMany(r => r.OrderProducts)
                .HasForeignKey(r => r.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .Property(r => r.ProductQuantity)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
