using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Master.Entities
{
    public class Basket
    {
        public Basket()
        {
            BasketLines = new HashSet<BasketLine>();
        }
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual ICollection<BasketLine> BasketLines { get; set; }


    }
}
