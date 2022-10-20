using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCommercePrototype.Domain.Repositories.Product.Stock
{
    public interface IStockRepository
    {
        Task<bool> CheckStockAsync(Guid productId,int quantity);
    }
}
