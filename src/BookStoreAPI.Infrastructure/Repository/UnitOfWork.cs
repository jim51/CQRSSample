using BooksStoreAPI.Application.Interfaces;

namespace BookStoreAPI.Infrastructure.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        public UnitOfWork(IBooksRepository booksRepository)
        {
            this.Books = booksRepository;
        }
        public IBooksRepository Books { get; }
    }
}
