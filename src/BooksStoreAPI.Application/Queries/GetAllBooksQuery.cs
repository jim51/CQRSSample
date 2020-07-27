using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BooksStoreAPI.Application.Interfaces;
using BooksStoreAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreAPI.Application.Queries
{
    public class GetAllBooksQuery :  IRequest<List<BookItemDto>>
    {
        public GetAllBooksQuery()
        {
            
        }
    }

    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllBooksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<BookItemDto>>  Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _unitOfWork.Books.GetAll();
            return books.ToList();
        }
    }
}
