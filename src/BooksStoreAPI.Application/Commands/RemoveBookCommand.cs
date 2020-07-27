using System.Threading;
using System.Threading.Tasks;
using BooksStoreAPI.Application.Interfaces;
using BooksStoreAPI.Models;
using MediatR;

namespace BooksStoreAPI.Application.Commands
{
    public class RemoveBookCommand : IRequest<BookItemDto>
    {
        public int Id { get; }

        public RemoveBookCommand(int Id)
        {
            this.Id = Id;
        }
    }

    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand, BookItemDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BookItemDto> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.Books.Delete(request.Id);
            return null; //TODO
        }
    }


}
