using eCommercePrototype.Common.Dto.MasterDto.Basket;
using eCommercePrototype.Common.Dto.MasterDto.Basket.BasketLine;
using eCommercePrototype.Domain.Infra.EFRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EF = eCommercePrototype.Common.Master.Entities;

namespace eCommercePrototype.Domain.Repositories.Basket
{
    public interface IBasketRepository : IEFRepository<EF.Basket>
    {
        Task<GetBasket> GetFromCustomerIdAsync(Guid customerId);
    }
}
