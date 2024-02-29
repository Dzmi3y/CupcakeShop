using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Core.Entities
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            Products = new List<Product>();
        }

        public Guid AdditionWeightId { get; set; }
        public virtual AdditionWeight? AdditionWeight { get; set; }
        public Guid AdditionDecorationId { get; set; }
        public virtual AdditionDecoration? AdditionDecoration { get; set; }
        public Guid AdditionSubspeciesId { get; set; }
        public virtual AdditionSubspecies? AdditionSubspecies { get; set; }

        public List<Product> Products { get; set; }
    }
}
