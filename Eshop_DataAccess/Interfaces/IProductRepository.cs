using Eshop_Domain.Entities;

namespace Eshop_DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> GetProduct(int Id);
        Task<Product> UpdateProduct(int id, Product product);
        Task<bool> DeleteProduct(int id);  
        Task<List<Product>> GetAllProducts();   
    }
}
