using System.Threading;
using System.Threading.Tasks;
using BooksStoreAPI.Application.Interfaces;
using BooksStoreAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BooksStoreAPI.Application.Commands
{
    public class UpdateBookCommand:IRequest<BookItemDto>
    {
        public BookItemDto BookItemDto { get; }

        public UpdateBookCommand(BookItemDto bookItemDto)
        {
            this.BookItemDto = bookItemDto;
        }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookItemDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookItemDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Books.Update(request.BookItemDto);
            return null;
        }
    }
}
