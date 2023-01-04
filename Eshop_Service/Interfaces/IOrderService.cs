using Eshop_Domain.DTO;
using Eshop_Domain.Entities;

namespace Eshop_Service.Interfaces
{
    public interface IOrderService
    {
        Task<int> CreateOrder(OrderDto order, string userEmail);
        Task<Order> GetOrder(int id);
    }
}
