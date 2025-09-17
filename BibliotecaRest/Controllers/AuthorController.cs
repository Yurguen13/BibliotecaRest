using Biblioteca.Rest.Services.Constants;
using Biblioteca.Rest.Services.DTOs;
using Biblioteca.Rest.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaRest.Controllers
{
    [Route("api/v1/author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthosService _authosService;

        public AuthorController(IAuthosService authorService)
        {
            _authosService = authorService;
        
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var author = await _authosService.GetAllAsync();

            return Ok(author);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authosService.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound(Messages.Error.AuthorNotFound);
            }
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AuthorCreateDto create)
        {
            try
            {
           bool res=await _authosService.AddAsync(create);

                if (res)
                {
                    return CreatedAtAction(nameof(GetById),
                 new { id = create.Id },
                 create);

                }
                return BadRequest(Messages.Error.AuthorBadRequest);

            }
            catch (Exception ex)
            {
                return BadRequest(Messages.Error.AuthorBadRequest);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AuthorCreateDto create)
        {
            try
            {
                var exist = await _authosService.GetByIdAsync(id);
                if (exist == null)
                {
                    return NotFound(Messages.Error.AuthorBadRequest);
                }
                await _authosService.UpdateAsync(id, create);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(Messages.Error.AuthorBadRequest);

            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var category = await _authosService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound(Messages.Error.AuthorBadRequest);
            }
            try
            {
                await _authosService.DeleteAsync(id);
                return NoContent();


            }
            catch (Exception ex)
            {
                return NotFound(Messages.Error.AuthorNotFound);
            }

        }
    }
}
