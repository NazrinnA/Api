using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Context.Repositories.Interfaces;
using WebApp.Entities;

namespace WebApp.Context.Repositories.Implementatios
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDb _db;

        public ProductRepository(AppDb db)
        {
            _db = db;
        }

        public async Task Create(Product product)
        {
            await _db.Products.AddAsync(product);
            await Save();
        }

        public async Task Delete(Product product)
        {
            product.IsActive = false;
            await Save();
        }

        public async Task<List<Product>> GetAll(Expression<Func<Product, bool>> exp = null, params string[] includes)
        {
            IQueryable<Product> query = _db.Products;
            if (includes is not null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return exp == null ? await query.ToListAsync() : await query.Where(exp).ToListAsync();
        }

        public async Task<Product> GetById(Expression<Func<Product, bool>> exp = null, params string[] includes)
        {
            IQueryable<Product> query = _db.Products;
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

        public async Task Update(Product product)
        {
            _db.Products.Update(product);
            await Save();
        }
    }
}
