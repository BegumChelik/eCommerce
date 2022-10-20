using eCommercePrototype.Common.Dto.MasterDto.Basket.BasketLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Dto.MasterDto.Basket
{
    public class GetBasket
    {
        public GetBasket()
        {
            BasketLines = new HashSet<GetBasketLine>();
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual ICollection<GetBasketLine> BasketLines { get; set; }
    }
}
