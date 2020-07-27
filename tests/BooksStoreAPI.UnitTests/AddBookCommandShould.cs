using Moq;
using System.Threading.Tasks;
using BooksStoreAPI.Application.Commands;
using BooksStoreAPI.Application.Interfaces;
using BooksStoreAPI.Models;
using MediatR;
using Xunit;

namespace booksapi.UnitTests
{
    public class AddBookCommandShould
    {
        [Fact]
        public async Task AddNewBooksAsync()
        {
            //Arrange
            var mediator = new  Mock<IMediator>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var request = new Mock<IRequest<BookItemDto>>();


            AddBookCommand addBookCommand = new AddBookCommand(new BookItemDto());
            AddBookCommandHandler addBookCommandHandler = new AddBookCommandHandler(unitOfWork.Object);

            //Act
            var x = await addBookCommandHandler.Handle(addBookCommand, new System.Threading.CancellationToken());

            //Assert
            //mediator.Verify(x => x.Send(request));


        }
    }
}
