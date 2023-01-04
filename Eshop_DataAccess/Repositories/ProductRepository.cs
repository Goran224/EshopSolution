using Eshop_DataAccess.Interfaces;
using Eshop_Domain;
using Eshop_Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop_DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EShopDbContext _dbContext;


        public ProductRepository(EShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            try
            { 
                await _dbContext.AddAsync(product);
                await _dbContext.SaveChangesAsync();

                return product;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try { 
            var product = await _dbContext.Set<Product>().FindAsync(id);
            _dbContext.Set<Product>().Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
             }
            catch(Exception ex) {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync(); 
        }

        public async Task<Product> GetProduct(int Id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
                
        }

        public async Task<Product> UpdateProduct(int id, Product product)
        {
            var productTobeUpdated = await GetProduct(id);
            productTobeUpdated.Name = product.Name;
            productTobeUpdated.Price = product.Price;
            productTobeUpdated.Description = product.Description;
            productTobeUpdated.PictureUrl = product.PictureUrl;

            _dbContext.Update(productTobeUpdated);
            await _dbContext.SaveChangesAsync();
            return productTobeUpdated;
        }
    }
}
