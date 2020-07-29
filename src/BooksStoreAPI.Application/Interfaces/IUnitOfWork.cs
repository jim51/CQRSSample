using System;

namespace BooksStoreAPI.Application.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IBooksRepository Books { get; }
        int Complete();
    }
}
