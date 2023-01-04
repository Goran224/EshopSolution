using Eshop_Domain.DTO;
using Eshop_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(OrderDto order, string userEmail);
        Task<Order> GetOrder(int Id);
        Task<Order> UpdateOrder(int id, Order order);
    }
}
