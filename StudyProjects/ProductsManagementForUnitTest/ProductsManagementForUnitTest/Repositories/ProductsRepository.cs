using Microsoft.EntityFrameworkCore;
using ProductsManagementForUnitTest.Contexts;
using ProductsManagementForUnitTest.Domains;
using ProductsManagementForUnitTest.Interfaces;

namespace ProductsManagementForUnitTest.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext _context;

        public ProductsRepository(ProductsContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Guid productId)
        {
            var product = await GetProductById(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductById(Guid productId)
        {
            return await _context.Products.FirstOrDefaultAsync(product => product.ProductId == productId)!;
        }

        public async Task<List<Product>> GetProducts()
        {
           return await _context.Products.ToListAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var findedProduct = await GetProductById(product.ProductId);

            if (findedProduct != null)
            {
                findedProduct.Name = product.Name;
                findedProduct.Price = product.Price;

                _context.Products.Update(findedProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
