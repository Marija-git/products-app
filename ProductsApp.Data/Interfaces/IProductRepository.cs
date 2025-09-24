using ProductsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        void Update(Product product);
        void Remove(Product product);

        Task<Product> GetByIdWithIncludesAsync(int id);
        Task<IEnumerable<Product>> GetAllWithIncludesAsync();
    }
}
