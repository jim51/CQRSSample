namespace BooksStoreAPI.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IBooksRepository Books { get; }
    }
}
