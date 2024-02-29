using CupcakeShop.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CupcakeShop.Database
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<AdditionDecoration> AdditionDecorations { get; set; }
        public DbSet<AdditionSubspecies> AdditionSubspecies { get; set; }
        public DbSet<AdditionWeight> AdditionWeights { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ImgUrl> ImgUrls { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ShortDetail> ShortDetails { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasOne(o => o.Cart);
            modelBuilder.Entity<Cart>().HasMany(c => c.Products);
            modelBuilder.Entity<Cart>().HasOne(c => c.AdditionSubspecies);
            modelBuilder.Entity<Cart>().HasOne(c => c.AdditionDecoration);
            modelBuilder.Entity<Cart>().HasOne(c => c.AdditionWeight);
            modelBuilder.Entity<Product>().HasOne(p=>p.ProductType);
            modelBuilder.Entity<Product>().HasMany(p => p.ShortDetails);
            modelBuilder.Entity<Product>().HasMany(p => p.ImgUrls);
            modelBuilder.Entity<Product>().HasMany(p => p.Recommendations);

        }


    }
}
