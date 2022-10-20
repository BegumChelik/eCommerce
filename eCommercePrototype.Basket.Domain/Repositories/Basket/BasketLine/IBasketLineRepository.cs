using eCommercePrototype.Common.Dto.MasterDto.Basket.BasketLine;
using eCommercePrototype.Domain.Infra.EFRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EF = eCommercePrototype.Common.Master.Entities;


namespace eCommercePrototype.Domain.Repositories.Basket.BasketLine
{
    public interface IBasketLineRepository : IEFRepository<EF.BasketLine>
    {
        Task<EF.BasketLine> GetByProductIdAsync(Guid basketId,Guid productId);
    }
}
