using CupcakeShop.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CupcakeShop.Core.Interfaces
{
    public interface IBestsellersService
    {
        public Task<IEnumerable<ShortProductInfoDTO>> GetBestsellrsAsync();
    }
}
