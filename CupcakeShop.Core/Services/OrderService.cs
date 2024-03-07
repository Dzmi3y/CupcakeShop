using AutoMapper;
using CupcakeShop.Core.DTOs;
using CupcakeShop.Core.Entities;
using CupcakeShop.Core.Extensions;
using CupcakeShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CupcakeShop.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAppDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IAppDbContext db, IMapper mapper, ILogger<OrderService> logger)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }

        public async Task<Guid?> SaveOrderAsync(OrderDTO orderDTO)
        {
            try
            {
                var resultOrder = _mapper.Map<Order>(orderDTO);

                _db.Orders.Add(resultOrder);
                await _db.SaveChangesAsync();
                return resultOrder.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetFormatedExceptionString());
                return null;
            }
        }

    }
}
