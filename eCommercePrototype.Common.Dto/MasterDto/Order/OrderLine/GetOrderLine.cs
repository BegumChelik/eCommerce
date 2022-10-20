using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Dto.MasterDto.Order.OrderLine
{
    public class GetOrderLine
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
