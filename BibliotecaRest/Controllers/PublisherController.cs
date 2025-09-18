using Biblioteca.Rest.Services.DTOs;
using Biblioteca.Rest.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaRest.Controllers
{
    [Route("api/v1/publishers")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var publishers = await _publisherService.GetAllAsync();
            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var publisher = await _publisherService.GetByIdAsync(id);

            if(publisher == null)
            {
                return NotFound(new { message = "El editorial no existe" });
            }

            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PublisherCreateDTO publisherDTO)
        {
            try
            {
                return CreatedAtAction(nameof (GetById), new { id = publisherDTO.Id }, publisherDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(new {message = $"Hubo un error al crear el editorial"});
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PublisherCreateDTO publisherDTO)
        {
            if(id != publisherDTO.Id)
            {
                return BadRequest(new {message="El ID de la ruta no coincide con el ID de la editorial"});
            }

            var existingPublisher = await _publisherService.GetByIdAsync(id);
            if (existingPublisher == null)
            {
                return NotFound(new { message = $"Editorial no encontrado" });
            }

            try
            {
                await _publisherService.UpdateAsync(id, publisherDTO);
                return NoContent();
            }
            catch (Exception ex) 
            { 
                return BadRequest(new {message = $"Hubo un error al actualizar la editorial{ex.Message}" });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingPublisher = await _publisherService.GetByIdAsync(id);
                if(existingPublisher == null)
                {
                    return NotFound(new { message = "Editorial no encontrado" });
                }

                await _publisherService.DeleteAsync(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                new
                {
                    message = $"Error al eliminar el editorial: {ex.Message}"
                });
            }
        }
    }
}
