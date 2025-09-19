using Biblioteca.Rest.Services.Constants;
using Biblioteca.Rest.Services.DTOs;
using Biblioteca.Rest.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaRest.Controllers
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var boks = await _bookService.GetAllAsync();

            return Ok(boks);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var books = await _bookService.GetByIdAsync(id);

            if (books == null)
            {
                return NotFound(Messages.Error.BooksNotFound);
            }
            return Ok(books);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] BookCreateDto create)
        {
            try
            {
                bool res = await _bookService.AddAsync(create);

                if (res)
                {
                    return CreatedAtAction(nameof(GetById),
                 new { id = create.Id },
                 create);

                }
                return BadRequest(Messages.Error.BooksBadRequest);

            }
            catch (Exception ex)
            {
                return BadRequest(Messages.Error.BooksBadRequest);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BookCreateDto create)
        {
            try
            {
                var exist = await _bookService.GetByIdAsync(id);
                if (exist == null)
                {
                    return NotFound(Messages.Error.BooksBadRequest);
                }
                await _bookService.UpdateAsync(id, create);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(Messages.Error.BooksBadRequest);

            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var books = await _bookService.GetByIdAsync(id);
            if (books == null)
            {
                return NotFound(Messages.Error.BooksBadRequest);
            }
            try
            {
                await _bookService.DeleteAsync(id);
                return NoContent();


            }
            catch (Exception ex)
            {
                return NotFound(Messages.Error.BooksNotFound);
            }

        }


    }
}
