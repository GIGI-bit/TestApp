using Entities;
using Entities.Entities;
using WebApiApp.DataAccess;
namespace WebApiApp.Services
{
    public class ProductService : IProductService
    {
        private IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<Product> Add(Product product)
        {
           await _productDal.Add(product);
            return product;
        }

        public async Task Delete(int id)
        {
            var product = await _productDal.GetById(p=>p.Id==id);
            await _productDal.Delete(product);
        }

        public async Task<Product>? GetProductById(int id)
        {
            return await _productDal.GetById(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
         return await _productDal.GetAll();
        }

        public async Task<Product>Update(Product product)
        {
            //var all = await _productDal.GetAll();
            //var item=all.FirstOrDefault(product => product.Id == product.Id);
            //if (item != null)
            //{
            //    item.Name = product.Name;
            //    item.Price = product.Price;
            //}
            await _productDal.Update(product);  
            return product;
        }
    }
}
