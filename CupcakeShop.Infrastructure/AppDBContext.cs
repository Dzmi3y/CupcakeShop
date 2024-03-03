using CupcakeShop.Core.Entities;
using CupcakeShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace CupcakeShop.Database
{
    public class AppDbContext :  DbContext, IAppDbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options):base(options) 
        {
        }

        public DbSet<AdditionDecoration> AdditionDecorations { get; set; }
        public DbSet<AdditionSubspecies> AdditionSubspecies { get; set; }
        public DbSet<AdditionWeight> AdditionWeights { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }



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
            modelBuilder.Entity<Product>().HasMany(p => p.Carts);
            modelBuilder.Entity<Cart>().HasOne(c => c.AdditionSubspecies);
            modelBuilder.Entity<Cart>().HasOne(c => c.AdditionDecoration);
            modelBuilder.Entity<Cart>().HasOne(c => c.AdditionWeight);
            modelBuilder.Entity<Product>().HasOne(p => p.ProductType);

            DataInitialization(modelBuilder);
        }

        private void DataInitialization(ModelBuilder modelBuilder)
        {
            int cakeProductTypeId = 1;
            int cookieProductTypeId = 2;
            int chouxProductTypeId = 3;
            int pizzaProductTypeId = 4;

            modelBuilder.Entity<ProductType>().HasData(
                new ProductType { Id = cakeProductTypeId, Name = "cake" },
                new ProductType { Id = cookieProductTypeId, Name = "cookie"},
                new ProductType { Id = chouxProductTypeId, Name = "choux" },
                new ProductType { Id = pizzaProductTypeId, Name = "pizza" }
                );

            modelBuilder.Entity<AdditionDecoration>().HasData(
                new AdditionDecoration { Id = Guid.NewGuid(), Name = "Without decoration", Price = 0 },
                new AdditionDecoration { Id = Guid.NewGuid(), Name = "Decor 1", Price = 1 },
                new AdditionDecoration { Id = Guid.NewGuid(), Name = "Decor 2", Price = 2 },
                new AdditionDecoration { Id = Guid.NewGuid(), Name = "Decor 3", Price = 3 }
                );

            modelBuilder.Entity<AdditionSubspecies>().HasData(
                new AdditionSubspecies { Id = Guid.NewGuid(), Name = "Default type", Price = 0 },
                new AdditionSubspecies { Id = Guid.NewGuid(), Name = "Type 1", Price = 1 },
                new AdditionSubspecies { Id = Guid.NewGuid(), Name = "Type 2", Price = 2 },
                new AdditionSubspecies { Id = Guid.NewGuid(), Name = "Type 3", Price = 3 }
                );

            modelBuilder.Entity<AdditionWeight>().HasData(
                new AdditionWeight { Id = Guid.NewGuid(), Weight = 0, UnitOfMeasurement = "g", Price = 0 },
                new AdditionWeight { Id = Guid.NewGuid(), Weight = 100, UnitOfMeasurement = "g", Price = 1 },
                new AdditionWeight { Id = Guid.NewGuid(), Weight = 300, UnitOfMeasurement = "g", Price = 2 },
                new AdditionWeight { Id = Guid.NewGuid(), Weight = 500, UnitOfMeasurement = "g", Price = 3 },
                new AdditionWeight { Id = Guid.NewGuid(), Weight = 1, UnitOfMeasurement = "kg", Price = 4 },
                new AdditionWeight { Id = Guid.NewGuid(), Weight = 1.5, UnitOfMeasurement = "kg", Price = 5 },
                new AdditionWeight { Id = Guid.NewGuid(), Weight = 2, UnitOfMeasurement = "kg", Price = 6 }
                );


            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Chocolate cake",
                    Weight = 1,
                    UnitOfMeasurement = "kg",
                    IsBestseller = true,
                    Price = 2,
                    ProductTypeId = cakeProductTypeId,
                    ImgUrl = "/images/cake.png",
                    ImgUrlsJson = "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                    Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                    Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                    ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                    StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit."
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Apple pie",
                    Weight = 2,
                    UnitOfMeasurement = "kg",
                    IsBestseller = false,
                    Price = 3,
                    ProductTypeId = cakeProductTypeId,
                    ImgUrl = "/images/cake.png",
                    ImgUrlsJson = "[\"/images/cake.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                    Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                    Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                    ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                    StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit."
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Chocolate Chip",
                    Weight = 100,
                    UnitOfMeasurement = "g",
                    IsBestseller = true,
                    Price = 1,
                    ProductTypeId = cookieProductTypeId,
                    ImgUrl = "/images/cookie.png",
                    ImgUrlsJson = "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                    Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                    Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                    ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                    StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit."
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Peanut Butter",
                    Weight = 500,
                    UnitOfMeasurement = "g",
                    IsBestseller = false,
                    Price = 5,
                    ProductTypeId = cookieProductTypeId,
                    ImgUrl = "/images/cookie.png",
                    ImgUrlsJson = "[\"/images/cookie.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                    Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                    Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                    ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                    StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit."
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Lemon Choux",
                    Weight = 100,
                    UnitOfMeasurement = "g",
                    IsBestseller = true,
                    Price = 1,
                    ProductTypeId = chouxProductTypeId,
                    ImgUrl = "/images/choux.png",
                    ImgUrlsJson = "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                    Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                    Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                    ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                    StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit."
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Strawberry Choux",
                    Weight = 400,
                    UnitOfMeasurement = "g",
                    IsBestseller = false,
                    Price = 4,
                    ProductTypeId = chouxProductTypeId,
                    ImgUrl = "/images/choux.png",
                    ImgUrlsJson = "[\"/images/choux.png\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                    Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                    Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                    ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                    StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit."
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Four Cheese",
                    Weight = 500,
                    UnitOfMeasurement = "g",
                    IsBestseller = true,
                    Price = 5,
                    ProductTypeId = pizzaProductTypeId,
                    ImgUrl = "/images/pizza.jpg",
                    ImgUrlsJson = "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                    Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                    Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                    ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                    StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit."
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Veggie",
                    Weight = 300,
                    UnitOfMeasurement = "g",
                    IsBestseller = false,
                    Price = 3,
                    ProductTypeId = pizzaProductTypeId,
                    ImgUrl = "/images/pizza.jpg",
                    ImgUrlsJson = "[\"/images/pizza.jpg\",\"/images/test1.png\", \"/images/test2.png\", \"/images/test3.png\", \"/images/test4.png\"]",
                    Description = "quibusdam praesentium nemo commodi! Provident dicta pariatur",
                    Delivery = "Lorem, ipsum dolor sit amet consectetur adipisicing elit. Est quos quasi in dolorem reiciendis,",
                    ShortDetailsJson = "[\"Lorem ipsum dolor sit amet\", \"consectetaur adipisicing elit\", \"sed do eiusmod tempor incididunt\", \"ut labore et dolore magna aliqua\"]",
                    StorageConditions = "unde sit modi possimus incidunt ab neque sunt fugit."
                }
            );
        }
    }
}
