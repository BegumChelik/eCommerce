using eCommercePrototype.Common.Dto.MasterDto.Basket.BasketLine;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Dto.MasterDto.Basket
{
    public class PostBasket
    {
        public PostBasket()
        {
            BasketLines = new HashSet<PostBasketLine>();
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual ICollection<PostBasketLine> BasketLines { get; set; }
    }
}
