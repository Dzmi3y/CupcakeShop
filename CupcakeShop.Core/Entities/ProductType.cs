using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Core.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int SequenceNumber { get; set; }
    }
}
