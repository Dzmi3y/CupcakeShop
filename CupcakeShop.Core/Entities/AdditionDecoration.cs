using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Core.Entities
{
    public class AdditionDecoration : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }

    }
}
