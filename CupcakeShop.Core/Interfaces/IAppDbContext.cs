using CupcakeShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CupcakeShop.Core.Interfaces
{
    public interface IAppDbContext : IDisposable
    {
        public DbSet<AdditionDecoration> AdditionDecorations { get; set; }
        public DbSet<AdditionSubspecies> AdditionSubspecies { get; set; }
        public DbSet<AdditionWeight> AdditionWeights { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
