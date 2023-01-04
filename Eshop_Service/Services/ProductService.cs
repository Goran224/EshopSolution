using Eshop_DataAccess.Interfaces;
using Eshop_Domain.DTO;
using Eshop_Domain.Entities;
using Eshop_Service.Interfaces;
using Eshop_Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepository) {
            _productRepo = productRepository;
        }
        public async Task<int> CreateProduct(ProductDto productDto)
        {
            
           var product = await _productRepo.CreateProduct(productDto.ProductToDomain());
            return product.Id; 
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepo.DeleteProduct(id);    
        }

        public async Task<Product> GetProduct(int Id)
        {
            var product = await _productRepo.GetProduct(Id);
            return product;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productRepo.GetAllProducts();
        }

        public async Task<int> UpdateProduct(int id, ProductDto productDto)
        {
            var product = await _productRepo.UpdateProduct(id, productDto.ProductToDomain());
            return product.Id;
        }
    }
}
