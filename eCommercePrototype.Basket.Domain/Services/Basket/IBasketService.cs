using eCommercePrototype.Common.Dto.MasterDto.Basket;
using eCommercePrototype.Common.Dto.MasterDto.Basket.BasketLine;
using eCommercePrototype.Common.Dto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommercePrototype.Domain.Services.Basket
{
    public interface IBasketService
    {
        Task<WebApiResponse<GetBasket>> GetBasketAsync(Guid customerId);
        Task<WebApiResponse<GetBasketLine>> AddLineToBasketAsync(Guid customerId, PostBasketLine request);
    }
}
