using System;
using System.Threading;
using System.Threading.Tasks;
using BooksStoreAPI.Application.Interfaces;
using BooksStoreAPI.Models;
using MediatR;

namespace BooksStoreAPI.Application.Queries
{
    public class GetBookByIDQuery : IRequest<BookItemDto>
    {
        public int Id { get; }

        public GetBookByIDQuery(int id)
        {
            Id = id;
        }
    }

    public class GetBookByIDQueryHandler : IRequestHandler<GetBookByIDQuery, BookItemDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetBookByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BookItemDto> Handle(GetBookByIDQuery request, CancellationToken cancellationToken)
        {
            var book = await _unitOfWork.Books.Get(request.Id);
            return book;
        }
    }
}
