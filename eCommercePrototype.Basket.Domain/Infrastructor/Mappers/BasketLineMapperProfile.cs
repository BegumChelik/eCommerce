using AutoMapper;
using eCommercePrototype.Common.Dto.MasterDto.Basket.BasketLine;
using eCommercePrototype.Common.Master.Entities;
using eCommercePrototype.Domain.Infrastructor.Extensions;

namespace eCommercePrototype.Domain.Infrastructor.Mappers
{
    public class BasketLineMapperProfile : Profile
    {
        public BasketLineMapperProfile()
        {
            CreateMap<BasketLine, PostBasketLine>().ReverseMap().IgnoreAllNonExisting();
            CreateMap<BasketLine, GetBasketLine>().ReverseMap().IgnoreAllNonExisting();
        }
    }
}
