using Biblioteca.Rest.Services.DTOs;
using Biblioteca.Rest.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaRest.Controllers
{
    [Route("api/v1/classifications")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        private readonly IClassificationService _classificationService;

        public ClassificationController(IClassificationService classificationService)
        {
            _classificationService = classificationService;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll()
        {
            var classifications = await _classificationService.GetAllAsync();

            return Ok(classifications);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var classification = await _classificationService.GetByIdAsync(id);

            if (classification == null)
            {
                return NotFound(new { message = "La clasificacion no existe" });
            }

            return Ok(classification);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClassificationCreateDTO classificationDTO)
        {
            try
            {
                return CreatedAtAction(nameof(GetById), new { id = classificationDTO.Id }, classificationDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Hubo un error al crear la clasificacion: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClassificationCreateDTO classificationDTO)
        {
            if (id != classificationDTO.Id)
            {
                return BadRequest(new { message = "El ID de la ruta no coincide con el ID de la clasificacion"});
            }

            var existingClassification = await _classificationService.GetByIdAsync(id);
            if (existingClassification == null) 
            {
                return NotFound(new { message = "Clasifacion no encontrada" });
            }

            try
            {
                await _classificationService.UpdateAsync(id, classificationDTO);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = $"Hubo un error al actualizar la clasificacion: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var existingClassification = await _classificationService.GetByIdAsync(id);
                if(existingClassification == null)
                {
                    return NotFound(new { message = "La clasificacion no se encuentra" });
                }

                await _classificationService.DeleteAsync(id);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = $"Error al eliminar la clasificacion"
                    });
            }
        }
    }
}
