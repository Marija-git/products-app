using Microsoft.EntityFrameworkCore.Storage;
using ProductsApp.Data.Interfaces;
using ProductsApp.Data.Models;
using System;

namespace ProductsApp.API.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductsDbContext _context;
        private IDbContextTransaction _transaction;

        private IRepository<Product> _products;
        private IRepository<Category> _categories;


        public UnitOfWork(ProductsDbContext context)
        {
            _context = context;
        }


        public IRepository<Product> Products => _products ??= new Repository<Product>(_context);
        public IRepository<Category> Categories => _categories ??= new Repository<Category>(_context);


        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context?.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
