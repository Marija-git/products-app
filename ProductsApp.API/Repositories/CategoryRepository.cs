using Microsoft.EntityFrameworkCore;
using ProductsApp.Data.Interfaces;
using ProductsApp.Data.Models;

namespace ProductsApp.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductsDbContext _context;
        private readonly DbSet<Category> _dbSet;

        public CategoryRepository(ProductsDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Category>();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
