using Microsoft.EntityFrameworkCore;
using ProductsApp.Data.Interfaces;
using ProductsApp.Data.Models;
using System.Linq.Expressions;

namespace ProductsApp.API.Repositories
{
    public class ProductRepository :  IProductRepository
    {
        private readonly ProductsDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(ProductsDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task AddAsync(Product entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(Product entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(Product entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<Product> GetByIdWithIncludesAsync(int id)
        {
            return await _dbSet.Include(p => p.Categories).FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetAllWithIncludesAsync()
        {
            return await _dbSet.Include(p => p.Categories).ToListAsync();
        }

        
    }
}
