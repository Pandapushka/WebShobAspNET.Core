using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Options;


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
        public DbSet<Image> Images { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
             Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // ВРЕМЕННОЕ подавление ошибки "PendingModelChangesWarning"
            //optionsBuilder.ConfigureWarnings(warnings =>
                //warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Product>()
                .Property(p => p.Cost)
                .HasColumnType("decimal(18, 2)"); // Указываем точность (18) и масштаб (2)

            modelBuilder.Entity<Image>().HasOne(p => p.Product).WithMany(i => i.Images).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(o => o.Cost)
                      .HasColumnType("decimal(18, 4)") // Указываем тип данных
                      .HasPrecision(18, 4);          // Указываем точность и масштаб
            });

            // Настройка связи между Product и Image
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Cart)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
