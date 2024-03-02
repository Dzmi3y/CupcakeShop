using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Core.DTOs
{
    public class ShortProductInfoDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public Guid ProductTypeId { get; set; }
        public double Weight { get; set; }
        public string UnitOfMeasurement { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
    }
}
