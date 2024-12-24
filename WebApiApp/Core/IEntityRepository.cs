using Entities.Entities;
using System.Linq.Expressions;
using System.Security.Principal;

namespace WebApiApp.Core
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<T> GetById(Expression<Func<T, bool>> predicate = null);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
