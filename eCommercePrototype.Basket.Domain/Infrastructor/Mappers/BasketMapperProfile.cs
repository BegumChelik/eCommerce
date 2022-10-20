using AutoMapper;
using eCommercePrototype.Common.Dto.MasterDto.Basket;
using eCommercePrototype.Domain.Infrastructor.Extensions;
using EF = eCommercePrototype.Common.Master.Entities;

namespace eCommercePrototype.Domain.Infrastructor.Mappers
{
    public class BasketMapperProfile : Profile
    {
        public BasketMapperProfile()
        {
            CreateMap<EF.Basket, PostBasket>().ReverseMap().IgnoreAllNonExisting();
            CreateMap<EF.Basket, GetBasket>().ReverseMap().IgnoreAllNonExisting();
        }
    }
}
