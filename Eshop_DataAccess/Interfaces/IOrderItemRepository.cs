using Eshop_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_DataAccess.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<OrderItem> CreateOrderItem(OrderItem orderItem);
        Task<OrderItem> GetOrderItem(int Id);
        Task<OrderItem> UpdateOrderItem(int id, OrderItem orderItem);
    }
}
