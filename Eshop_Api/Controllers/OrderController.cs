using Eshop_Domain.DTO;
using Eshop_Domain.Entities;
using Eshop_Service.Interfaces;
using Eshop_Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eshop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
            private readonly IOrderService _orderService;
            public OrderController(IOrderService orderService)
            {

            _orderService = orderService;
            }

            [AllowAnonymous]
            [HttpPost]
            public async Task<IActionResult> CreateOrder(OrderDto order)
            {
                try
                {
                  await _orderService.CreateOrder(order);   
                  return Ok();  
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

        [HttpGet]
        public async Task<Order> GetOrder(int id)
        {

            return await _orderService.GetOrder(id);
        }
    }
}
