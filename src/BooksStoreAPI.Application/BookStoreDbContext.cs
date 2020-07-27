using BooksStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreAPI.Application
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }

        public DbSet<BookItemDto> BookItems { get; set; }

    }

}
