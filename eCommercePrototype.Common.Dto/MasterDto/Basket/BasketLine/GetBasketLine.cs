using eCommercePrototype.Common.Dto.MasterDto.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Dto.MasterDto.Basket.BasketLine
{
    public class GetBasketLine
    {
        public Guid Id { get; set; }
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual GetProduct Product { get; set; }
        public virtual GetProductPrice Price { get; set; }

    }
}
