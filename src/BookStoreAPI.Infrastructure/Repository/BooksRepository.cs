using System.Collections.Generic;
using System.Threading.Tasks;
using BooksStoreAPI.Application.Interfaces;
using BooksStoreAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookStoreAPI.Infrastructure.Repository
{
    public class BooksRepository: IBooksRepository
    {
        private readonly BookStoreDbContext _context;
        public BooksRepository(BookStoreDbContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(int id)
        {
            var book = await _context.BookItems.FindAsync(id);
            _context.BookItems.Remove(book);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<int> Update(BookItemDto entity)
        {
            var book = await _context.BookItems.FindAsync(entity);
            this._context.Entry(book).CurrentValues.SetValues(entity);
            await this._context.SaveChangesAsync();
            return 1;
        }

        public async Task<int> Add(BookItemDto entity)
        {
            _context.BookItems.Add(entity);
            await _context.SaveChangesAsync();
            return 1;
        }

        public async Task<BookItemDto> Get(int id)
        {
            return await _context.BookItems.FindAsync(id);
        }

        public async Task<IEnumerable<BookItemDto>> GetAll()
        {
            return await _context.BookItems.ToListAsync();
        }
    }
}
