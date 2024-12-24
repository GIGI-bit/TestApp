using Entities;
using Entities.Entities;
using WebApiApp.Core;

namespace WebApiApp.DataAccess
{
    public interface IProductDal: IEntityRepository<Product>
    {
    }
}
