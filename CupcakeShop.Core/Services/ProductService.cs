using AutoMapper;
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
    public class ProductService : IProductService
    {
        private readonly IAppDbContext _db;
        private readonly IMapper _mapper;

        public ProductService(IAppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
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

        public async Task<CatalogPageDTO> GetCatalogPageAsync(int? typeid, int pageNumber = 1, int groupBy = 15)
        {
            var result = new CatalogPageDTO();

            result.totalPagesNumber = await _db.Products.CountAsync();

            result.list = await _db.Products
                .Where(p => typeid == null || p.ProductType == null || p.ProductType.Id == typeid)
                .Skip((pageNumber-1)* groupBy)
                .Take(groupBy)
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


            return result;
        }

        public async Task<FullProductInfoDTO?> GetFullProductAsync(Guid productId)
        {
            var product = await _db.Products.Include(p=>p.ProductType).FirstOrDefaultAsync(p=>p.Id==productId);

            return _mapper.Map<FullProductInfoDTO>(product);
        }
    }
}
