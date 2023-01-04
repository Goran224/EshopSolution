using Eshop_DataAccess.Interfaces;
using Eshop_Domain;
using Eshop_Domain.DTO;
using Eshop_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Eshop_DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly EShopDbContext _dbContext;


        public OrderRepository(EShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Order> CreateOrder(OrderDto orderDto)
        {
            var order = new Order();
            decimal total = 0;
            order.Address = orderDto.Address;
            order.Status = orderDto.Status; 
            await _dbContext.Order.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            foreach (var orderItemProps in orderDto.OrderItems)
           { 
                var orderItem = new OrderItem();    
                orderItem.OrderId = order.Id;
                orderItem.ProductId = orderItemProps.ProductId;
                orderItem.Quantity = orderItemProps.Quantity;
                orderItem.Product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id== orderItemProps.ProductId);    
                await _dbContext.OrderItem.AddAsync(orderItem);
                total += orderItem.Product.Price * orderItemProps.Quantity;
           }
            order.Total = total;    
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrder(int Id)
        {
            var order = await _dbContext.Order.Include(x => x.OrderItems).ThenInclude(x => x.Product).FirstOrDefaultAsync(x => x.Id == Id);
            return order;
        }

        public Task<Order> UpdateOrder(int id, Order order)
        {
            throw new NotImplementedException();
        }
    }
}
