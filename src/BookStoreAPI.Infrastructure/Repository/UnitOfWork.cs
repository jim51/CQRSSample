using System;
using BooksStoreAPI.Application.Interfaces;

namespace BookStoreAPI.Infrastructure.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly BookStoreDbContext _context;
        public IBooksRepository Books { get; }

        public UnitOfWork(BookStoreDbContext bookStoreDbContext)
        {
            this._context = bookStoreDbContext;
            this.Books = new BooksRepository(_context);
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
