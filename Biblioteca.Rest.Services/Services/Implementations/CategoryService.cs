using Biblioteca.Rest.Services.DTOs;
using Biblioteca.Rest.Services.Services.Interfaces;
using BibliotecaRest.Data.Data;
using BibliotecaRest.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Rest.Services.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<ICollection<CategoryReadDto>> GetAllAsync()
        {

         var categoria  =   await _context.Category
                .Where(x => !x.IsDeleted && !x.Active)
                .Select(x => new CategoryReadDto
                {
                    Id= x.Id,
                    Name= x.Name,
                    Description= x.Description,

                }).ToListAsync();

            return categoria;

        }

        public async Task<CategoryReadDto> GetById(int id)
        {
         var categories =  await _context.Category
                .Where(x => x.Id == id)
                .Select(x => new CategoryReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,

                }).FirstOrDefaultAsync();

            return categories;
        }

        public async Task AddAsync(CategoryCreateDto category)
        {
            try
            {
                Category cate = new Category();
                cate.Id = category.Id;
                cate.Name = category.Name;
                cate.Description = category.Description;
                await _context.Category.AddAsync(cate);
                await _context.SaveChangesAsync();
                    

            }catch (Exception ex)
            {

            }
        }

        public async Task UpdateAsync(int id , CategoryCreateDto category)
        {

            
        }









    }
}
