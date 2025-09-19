using Biblioteca.Rest.Services.DTOs;
using Biblioteca.Rest.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaRest.Controllers
{
    [ApiController]
    [Route("api/v1/specimens")]
    public class SpecimensController : ControllerBase
    {
        private readonly ISpecimensService _specimensService;

        public SpecimensController(ISpecimensService specimensService)
        {
            _specimensService = specimensService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var specimens = await _specimensService.GetAllAsync();
            return Ok(specimens);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var specimen = await _specimensService.GetByIdAsync(id);

            if (specimen == null)
            {
                return NotFound(new { message = "El especimen no existe" });
            }
            return Ok(specimen);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SpecimensCreateDTO specimenDTO)
        {
            try
            {
                await _specimensService.AddAsync(specimenDTO);
                return CreatedAtAction(nameof(GetById), new { id = specimenDTO.Id }, specimenDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Hubo un error al crear el especimen" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SpecimensCreateDTO specimenDTO)
        {
            if (id != specimenDTO.Id)
            {
                return BadRequest(new { message = "El ID del ruta no coincide con el ID del especimen" });
            }

            var existingPublisher = await _specimensService.GetByIdAsync(id);
            if (existingPublisher == null)
            {
                return NotFound(new { message = $"Especimen no encontrado" });
            }

            try
            {
                await _specimensService.UpdateAsync(id, specimenDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Hubo un error al actualizar el especimen{ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingSpecimen = await _specimensService.GetByIdAsync(id);
                if(existingSpecimen == null)
                {
                    return NotFound(new { message = "Specimen no encontrado" });
                }
                await _specimensService.DeleteAsync(id);
                return NoContent();
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        message=$"Error al eliminar el especimen: {ex.Message}"
                    });
            }
        }
    }
}
