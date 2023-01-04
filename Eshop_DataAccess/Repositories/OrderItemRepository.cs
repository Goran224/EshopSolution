using Eshop_DataAccess.Interfaces;
using Eshop_Domain;
using Eshop_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_DataAccess.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly EShopDbContext _dbContext;


        public OrderItemRepository(EShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<OrderItem> CreateOrderItem(OrderItem orderItem)
        {
            await _dbContext.AddAsync(orderItem); 
            return orderItem;
        }

        public Task<OrderItem> GetOrderItem(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderItem> UpdateOrderItem(int id, OrderItem orderItem)
        {
            throw new NotImplementedException();
        }
    }
}
