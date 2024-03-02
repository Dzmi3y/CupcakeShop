using CupcakeShop.Core.DTOs;
using CupcakeShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Core.Services
{
    public class BestsellersService : IBestsellersService
    {
        private readonly IAppDbContext _db;
        public BestsellersService(IAppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ShortProductInfoDTO>> GetBestsellrsAsync()
        {
            return await _db.Products
                .Where(p => p.IsBestseller)
                .Select(p => new ShortProductInfoDTO
                {
                    Id = p.Id,
                    ImgUrl = p.ImgUrl,
                    Name = p.Name,
                    Price = p.Price,
                    ProductTypeId = p.ProductTypeId,
                    TypeName = (p.ProductType != null) ? p.ProductType.Name : string.Empty,
                    UnitOfMeasurement = p.UnitOfMeasurement,
                    Weight = p.Weight
                }).AsNoTracking().ToListAsync();
        }
    }
}
