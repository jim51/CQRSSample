using System.Collections.Generic;
using System.Threading.Tasks;
using BooksStoreAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using BooksStoreAPI.Application.Commands;
using BooksStoreAPI.Application.Queries;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookItemsController( IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookItemDto>>> GetBookItems()
        {
            var bookItems = await this._mediator.Send(new GetAllBooksQuery());

            if (bookItems == null)
            {
                return NotFound();
            }

            return bookItems;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookItemDto>> GetBookItem(int id)
        {
            var bookItem = await this._mediator.Send(new GetBookByIDQuery(id));

            if (bookItem == null)
            {
                return NotFound();
            }

            return bookItem;
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookItem(int id, BookItemDto bookItemDto)
        {
            if (id != bookItemDto.Id)
            {
                return BadRequest();
            }
            await this._mediator.Send(new UpdateBookCommand(bookItemDto));
            return NoContent();
        }
       
        [HttpPost]
        public async Task<ActionResult<BookItemDto>> PostBookItem(BookItemDto bookItemDto)
        {
            await this._mediator.Send(new AddBookCommand(bookItemDto));
            return Ok(new BookItemDto());
        }
      
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookItemDto>> DeleteBookItem(int id)
        {
            await this._mediator.Send(new RemoveBookCommand(id));
            return Ok(new BookItemDto());
        }
    }
}
