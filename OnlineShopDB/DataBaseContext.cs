using Microsoft.EntityFrameworkCore;
using OnlineShopDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopDB
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
             Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Cost)
                .HasColumnType("decimal(18, 2)"); // Указываем точность (18) и масштаб (2)
        }
    }
}
