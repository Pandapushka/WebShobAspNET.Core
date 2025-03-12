using Microsoft.EntityFrameworkCore;
using OnlineShopDB.Models;
using WebShobGleb.Models;

namespace OnlineShopDB
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<UserLikeProducts> UserLikeProducts { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
             Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Cost)
                .HasColumnType("decimal(18, 2)"); // Указываем точность (18) и масштаб (2)

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Cart)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
