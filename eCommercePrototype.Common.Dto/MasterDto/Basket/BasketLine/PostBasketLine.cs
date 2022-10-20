using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Dto.MasterDto.Basket.BasketLine
{
   public class PostBasketLine
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
