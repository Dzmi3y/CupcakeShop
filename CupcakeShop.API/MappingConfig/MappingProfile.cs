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
            CreateMap<CartDTO, Cart>();
            CreateMap<OrderDTO, Order>();
        }
    }
}
