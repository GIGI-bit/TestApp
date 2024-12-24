using Entities;
using Entities.Entities;
using WebApiApp.Core;
using WebApiApp.Data;

namespace WebApiApp .DataAccess
{
    public class ProductDal : EFEntityBaseRepository<ProductDb_Testing, Product>, IProductDal
    {
        public ProductDal(ProductDb_Testing context) : base(context)
        {
        }
    }
}
