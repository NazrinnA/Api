using System.Linq.Expressions;
using WebApp.Entities;

namespace WebApp.Context.Repositories.Interfaces
{
	public interface ICategoryRepository
	{
		Task<List<Category>> GetAll(Expression<Func<Category, bool>> exp = null,params string[] includes);
		Task<Category> Get(Expression<Func<Category, bool>> exp = null, params string[] includes);
		Task Delete(Category category);
		Task Update(Category category);
		Task Create(Category category);
		Task Save();
	}
}
