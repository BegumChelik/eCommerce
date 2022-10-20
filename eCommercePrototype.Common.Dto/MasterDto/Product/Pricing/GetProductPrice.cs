using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Dto.MasterDto.Product
{
    public class GetProductPrice
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public double Price { get; set; }
        public DateTime InsertDate { get; set; }
        public bool IsActive { get; set; }
    
    }
}
