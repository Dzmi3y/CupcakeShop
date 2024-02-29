using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Core.Entities
{
    public class ImgUrl : BaseEntity
    {
        public string Url { get; set; } = string.Empty;

        public Guid ProductId { get; set; }
        public virtual Product? Product { get; set; }
    }
}
