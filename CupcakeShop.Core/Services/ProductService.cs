using AutoMapper;
using CupcakeShop.Core.DTOs;
using CupcakeShop.Core.Extensions;
using CupcakeShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CupcakeShop.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IAppDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IAppDbContext db, IMapper mapper, ILogger<ProductService> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ShortProductInfoDTO>?> GetBestsellrsAsync()
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError(ex.GetFormatedExceptionString());
                return null;
            }
        }

        public async Task<CatalogPageDTO?> GetCatalogPageAsync(int? typeid, int pageNumber = 1, int groupBy = 15)
        {
            try
            {
                var result = new CatalogPageDTO();
                var productsCount = await _db.Products.CountAsync();
                double totalPagesNumber = productsCount / groupBy;
                result.totalPagesNumber = (int)Math.Ceiling(totalPagesNumber);

                result.list = await _db.Products
                    .Where(p => typeid == null || p.ProductType == null || p.ProductType.Id == typeid)
                    .Skip((pageNumber - 1) * groupBy)
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
            catch (Exception ex)
            {
                _logger.LogError(ex.GetFormatedExceptionString());
                return null;
            }
        }

        public async Task<FullProductInfoDTO?> GetFullProductAsync(Guid productId)
        {
            try
            {
                var product = await _db.Products.AsNoTracking().Include(p => p.ProductType).FirstOrDefaultAsync(p => p.Id == productId);

                return _mapper.Map<FullProductInfoDTO>(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetFormatedExceptionString());
                return null;
            }
        }

        public async Task<AdditionalParamsDTO?> GetAdditionalParamsAsync()
        {
            try
            {
                return new AdditionalParamsDTO
                {
                    Decorations = await _db.AdditionDecorations.AsNoTracking().ToListAsync(),
                    Subspecies = await _db.AdditionSubspecies.AsNoTracking().ToListAsync(),
                    Weights = await _db.AdditionWeights.AsNoTracking().ToListAsync()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetFormatedExceptionString());
                return null;
            }
        }
    }
}
