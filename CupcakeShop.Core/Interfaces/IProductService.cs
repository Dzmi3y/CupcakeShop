using CupcakeShop.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CupcakeShop.Core.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ShortProductInfoDTO>> GetBestsellrsAsync();
        public Task<CatalogPageDTO> GetCatalogPageAsync(int? typeid, int pageNumber = 1, int groupBy = 15);
        public Task<FullProductInfoDTO?> GetFullProductAsync(Guid productId);
    }
}
