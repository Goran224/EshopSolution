using Eshop_DataAccess.Interfaces;
using Eshop_Domain.DTO;
using Eshop_Domain.Entities;
using Eshop_Service.Interfaces;

namespace Eshop_Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }
        public async Task<int> CreateOrder(OrderDto order)
        {
            var result = await _orderRepo.CreateOrder(order);
            return result.Id;
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _orderRepo.GetOrder(id);
        }
    }
}
