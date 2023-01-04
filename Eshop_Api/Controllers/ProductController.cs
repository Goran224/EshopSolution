using Eshop_Domain.DTO;
using Eshop_Domain.Entities;
using Eshop_Service.Interfaces;
using Eshop_Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eshop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) {

            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetProduct(int id) {
            try
            {
                return await _productService.GetProduct(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult>  CreateProduct(ProductDto productDto)
        {
            try
            {
                if(CheckIfAdmin())
                {
                    var productid = await _productService.CreateProduct(productDto);
                    return Ok(productid);
                }
                else return Unauthorized(ErrorMessages.AdminPermission);
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            }

        [Authorize]
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            try
            {
                
                if (CheckIfAdmin())
                {
                    var productid = await _productService.UpdateProduct(id,productDto);
                    return Ok(productid);
                }
                else return Unauthorized();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [Authorize]
        [HttpPost("Delete prod")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                if (CheckIfAdmin())
                {
                    bool deleted = await _productService.DeleteProduct(id);
                    if (deleted)
                    {
                        return Ok(id);
                    }
                }
                return Unauthorized(ErrorMessages.AdminPermission);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Get All Products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            try
            {
               return  await _productService.GetProducts();    
            }
            catch (Exception ex) {

            return BadRequest(ex.Message);
            }

        }

        private bool CheckIfAdmin()
        {
            var isAdmin = User.FindFirst("isAdmin")?.Value;
            return Convert.ToBoolean(isAdmin);
        }

    }
}
