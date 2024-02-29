using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ImgUrls = new List<ImgUrl>();
            ShortDetails = new List<ShortDetail>();
            Recommendations = new List<Product>();
        }

        public string Name { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public bool IsBestseller { get; set; }
        public double Weight { get; set; }
        public string UnitOfMeasurement { get; set; } = string.Empty;
        public double Price { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string StringstorageConditions { get; set; } = string.Empty;
        public string Delivery { get; set; } = string.Empty;

        public Guid ProductTypeId { get; set; }
        public virtual ProductType? ProductType { get; set; }

        public List<ImgUrl> ImgUrls { get; set; }
        public List<ShortDetail> ShortDetails { get; set; }
        public List<Product> Recommendations { get; set; }
    }
}
