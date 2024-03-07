using CupcakeShop.Core.DTOs;

namespace CupcakeShop.Core.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ShortProductInfoDTO?>> GetBestsellrsAsync();
        public Task<CatalogPageDTO?> GetCatalogPageAsync(int? typeid, int pageNumber = 1, int groupBy = 15);
        public Task<FullProductInfoDTO?> GetFullProductAsync(Guid productId);
        public Task<AdditionalParamsDTO?> GetAdditionalParamsAsync();
    }
}
