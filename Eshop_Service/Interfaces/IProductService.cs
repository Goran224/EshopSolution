using Eshop_Domain.DTO;
using Eshop_Domain.Entities;

namespace Eshop_Service.Interfaces
{
    public interface IProductService
    {
        Task<int> CreateProduct(ProductDto product);
        Task<Product> GetProduct(int Id);
        Task<List<Product>> GetProducts();
        Task<int> UpdateProduct(int id, ProductDto product);
        Task<bool> DeleteProduct(int id); 
    }
}
