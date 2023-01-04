using Eshop_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_Domain.DTO
{
    public class OrderDto
    {
        public string Address { get; set; }
        public decimal Total { get; set; }
        public IList<OrderItemDto> OrderItems { get; set; }
        public OrderStatus Status { get; set; }
    }
}
