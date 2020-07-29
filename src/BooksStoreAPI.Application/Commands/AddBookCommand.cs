using System.Threading;
using System.Threading.Tasks;
using BooksStoreAPI.Application.Interfaces;
using BooksStoreAPI.Models;
using MediatR;

namespace BooksStoreAPI.Application.Commands
{
    public class AddBookCommand : IRequest<BookItemDto>
    {
        public BookItemDto BookItemDto { get; }

        public AddBookCommand(BookItemDto bookItemDto)
        {
            this.BookItemDto = bookItemDto;
        }
    }

    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookItemDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<BookItemDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.Books.Add(request.BookItemDto);
                _unitOfWork.Complete();
            } 
            
            return null;//TODO: Automapper to map returning DTO object
        }
    }
}
