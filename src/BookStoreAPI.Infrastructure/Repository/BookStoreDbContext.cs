using BooksStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Infrastructure.Repository
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        { }

        public DbSet<BookItemDto> BookItems { get; set; }

    }

}
