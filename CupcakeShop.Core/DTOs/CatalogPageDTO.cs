using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Core.DTOs
{
    public class CatalogPageDTO
    {
        public CatalogPageDTO()
        {
            list = new List<ShortProductInfoDTO>();
        }
        public IEnumerable<ShortProductInfoDTO> list { get; set; }
        public int totalPagesNumber { get; set; }
    }
}
