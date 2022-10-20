using System;
using System.Collections.Generic;
using System.Text;

namespace eCommercePrototype.Common.Dto.MasterDto.Product
{
    public class GetStock
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int StockCount { get; set; }
        public DateTime InsertDate { get; set; }
        public int SaledCount { get; set; }
    }
}
