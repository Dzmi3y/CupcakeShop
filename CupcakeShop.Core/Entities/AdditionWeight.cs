using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Core.Entities
{
    public class AdditionWeight : BaseEntity
    {
        public double Weight { get; set; }
        public string UnitOfMeasurement { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
