using CupcakeShop.Core.DTOs;

namespace CupcakeShop.Core.Interfaces
{
    public interface IOrderService
    {
        public Task<Guid> SaveOrderAsync(OrderDTO orderDTO);
    }
}
