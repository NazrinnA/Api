using System.Linq.Expressions;
using WebApp.Entities;

namespace WebApp.Context.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll(Expression<Func<Product, bool>> exp = null, params string[] includes);
        Task<Product> Get(Expression<Func<Product, bool>> exp = null, params string[] includes);
        Task Delete(Product category);
        Task Update(Product category);
        Task Create(Product category);
        Task Save();
    }
}
