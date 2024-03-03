using AutoMapper;
using CupcakeShop.Core.DTOs;
using CupcakeShop.Core.Entities;
using CupcakeShop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CupcakeShop.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IAppDbContext _db;
        private readonly IMapper _mapper;
        public OrderService(IAppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<Guid> SaveOrderAsync(OrderDTO orderDTO)
        {
            var resultOrder = _mapper.Map<Order>(orderDTO);
            resultOrder.Id = Guid.NewGuid();
            if (orderDTO.Cart != null)
            {

                var products = await _db.Products.Where(p => orderDTO.Cart.ProductIdList.Contains(p.Id)).ToListAsync();
                var additionSubspecies = await _db.AdditionSubspecies.FirstOrDefaultAsync(s => s.Id == orderDTO.Cart.AdditionSubspeciesId);
                var additionWeight = await _db.AdditionWeights.FirstOrDefaultAsync(w => w.Id == orderDTO.Cart.AdditionWeightId);
                var additionDecoration = await _db.AdditionDecorations.FirstOrDefaultAsync(d => d.Id == orderDTO.Cart.AdditionDecorationId);

                var cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    AdditionSubspecies = additionSubspecies,
                    AdditionWeight = additionWeight,
                    AdditionDecoration = additionDecoration,
                    Products = products,
                };
                resultOrder.Cart = cart;
            }

            _db.Orders.Add(resultOrder);
            await _db.SaveChangesAsync();
            return resultOrder.Id;
        }

    }
}
