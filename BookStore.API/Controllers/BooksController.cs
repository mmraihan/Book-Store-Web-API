﻿ using BookStore.API.Model;
using BookStore.API.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books =await _bookRepository.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] int Id)
        {
            var book = await _bookRepository.GetBookByIdAsync(Id);
            if (book==null)
            {
                return NotFound("There is no book in this id");
            }
            return Ok(book);
        }


        [HttpPost("")]
        public async Task<IActionResult> AddNewBook([FromBody] BookModel bookModel)
        {
            var id = await _bookRepository.AddBookAsync(bookModel);
            return CreatedAtAction(nameof(GetBookById), new {id=id, controller="books" }, id );
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookModel bookModel, [FromRoute] int id)
        {
           await _bookRepository.UpdateBookAsync(id,bookModel);
            return Ok();
           
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBookPatchAsync([FromBody] JsonPatchDocument bookModel, [FromRoute] int id)
        {
            await _bookRepository.UpdateBookPatchAsync(id, bookModel);
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBookAsyn(id);
            return Ok();

        }

    }
}
