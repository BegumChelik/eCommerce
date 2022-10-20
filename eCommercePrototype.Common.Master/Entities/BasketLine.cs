using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Master.Entities
{
    public class BasketLine
    {
        public Guid Id { get; set; }
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }


    }
}
