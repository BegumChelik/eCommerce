using eCommercePrototype.Common.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Dto.MasterDto.Order
{
    public class GetOrder
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid InvoiceId { get; set; }
        public Guid ShippingId { get; set; }
        public Guid PaymentId { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
    }
}
