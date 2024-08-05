using ProductsManagementForUnitTest.Domains;

namespace ProductsManagementForUnitTest.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(Guid productId);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(Guid productId);
    }
}
