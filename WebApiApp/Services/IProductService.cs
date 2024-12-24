using Entities.Entities;

namespace WebApiApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product>? GetProductById(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task Delete(int id);
    }
}
