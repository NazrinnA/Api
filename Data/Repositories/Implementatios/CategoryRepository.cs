using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Context.Repositories.Interfaces;
using WebApp.Entities;

namespace WebApp.Context.Repositories.Implementatios
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly AppDb _db;

		public CategoryRepository(AppDb db)
		{
			_db = db;
		}

		public async Task Create(Category category)
		{
			await _db.Categories.AddAsync(category);
			await Save();
		}

		public async Task Delete(Category category)
		{
			category.IsActive = false;
			await Save();
		}

		public async Task<List<Category>> GetAll(Expression<Func<Category, bool>> exp = null, params string[] includes)
		{
			IQueryable<Category> query = _db.Categories;
			if (includes is not null)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}
			return exp == null ? await query.ToListAsync():await query.Where(exp).ToListAsync();
		}

		public async Task<Category> GetById(Expression<Func<Category, bool>> exp = null, params string[] includes)
		{
			IQueryable<Category> query = _db.Categories;
			if (includes is not null)
			{
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
			}
			return exp == null ? await query.FirstOrDefaultAsync() : await query.Where(exp).FirstOrDefaultAsync();
		}

		public async Task Save()
		{
			await _db.SaveChangesAsync();
		}

		public async Task Update(Category category)
		{
			_db.Categories.Update(category);
			await Save();
		}
	}
}
