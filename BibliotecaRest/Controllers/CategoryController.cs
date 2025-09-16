using Biblioteca.Rest.Services.Constants;
using Biblioteca.Rest.Services.DTOs;
using Biblioteca.Rest.Services.Services.Interfaces;
using BibliotecaRest.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaRest.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryService.GetAllAsync();

            return Ok(category);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound(Messages.Error.CategoryNotFound);
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto create)
        {
            try
            {
                await _categoryService.AddAsync(create);
                return CreatedAtAction(nameof(GetById),
                    new { id = create.Id },
                    create);

            }
            catch (Exception ex)
            {
                return BadRequest(Messages.Error.CategoryBadRequest);
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id,CategoryCreateDto create)
        {
            try
            {
            var exist=    await _categoryService.GetByIdAsync(id);
                if(exist==null)
                {
                    return NotFound(Messages.Error.CategoryNotFound);
                }
                await _categoryService.UpdateAsync(id, create);
                return NoContent();

            }catch(Exception ex)
            {
                return BadRequest(Messages.Error.CategoryBadRequest);

            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {

            var category = await _categoryService.GetByIdAsync(id);
            if(category==null)
            {
                return NotFound(Messages.Error.CategoryNotFound);
            }
            try
            {
                await _categoryService.DeleteAsync(id);
                return NoContent();


            }
            catch (Exception ex)
            {
                return NotFound(Messages.Error.CategoryNotFound);
            }

        }

    }

}

