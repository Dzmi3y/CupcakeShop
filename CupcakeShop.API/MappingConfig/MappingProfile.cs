using AutoMapper;
using CupcakeShop.Core.DTOs;
using CupcakeShop.Core.Entities;

namespace CupcakeShop.API.MappingConfig
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Product, FullProductInfoDTO>()
                .ForMember(dto => dto.TypeName, opt => opt.MapFrom(p => (p.ProductType != null) ? p.ProductType.Name : string.Empty));
            CreateMap<CartItemDTO, OrderedProduct>()
                .ForMember(op => op.Id, opt => opt.MapFrom(dto => Guid.NewGuid()));
            CreateMap<OrderDTO, Order>()
                .ForMember(o => o.Id, opt => opt.MapFrom(dto => Guid.NewGuid()))
                .ForMember(o => o.OrderedProducts, opt => opt.MapFrom(dto => dto.Cart));
        }
    }
}
