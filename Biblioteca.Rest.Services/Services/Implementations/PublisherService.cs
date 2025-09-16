using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Rest.Services.Constants;
using Biblioteca.Rest.Services.DTOs;
using Biblioteca.Rest.Services.Services.Interfaces;
using BibliotecaRest.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Rest.Services.Services.Implementations
{
    public class PublisherService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public PublisherService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> AddAsync(CategoryCreateDto creatDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<PublisherReadDTO>> GetAllAsync()
        {
            var publishers = await _context.Publisher
                .Where(p => !p.IsDeleted)
                .Select(p => new PublisherReadDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    City = p.City,
                    Country = p.Country,
                    Phone = p.Phone,
                })
                .ToListAsync();
            return publishers;
        }

        public async Task <PublisherReadDTO>GetByIdAsync(int id)
        {
            var publisher = await _context.Publisher
                .Where(p => p.Id == id && !p.IsDeleted)
                .Select(p => new PublisherReadDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    City = p.City,
                    Country = p.Country,
                    Phone = p.Phone,
                })
                .FirstOrDefaultAsync();
                if(publisher == null)
                    throw new ApplicationException(string.Format(Messages.Error.PublisherNotFoundWithId, id));
                return publisher;
        }

        public Task<bool> UpdateAsync(int id, CategoryCreateDto tcreatDto)//ELIMINAR
        {
            throw new NotImplementedException();
        }

        Task<ICollection<CategoryReadDto>> IGenericService<CategoryCreateDto, CategoryReadDto, CategoryCreateDto>.GetAllAsync()//ELIMINAR
        {
            throw new NotImplementedException();
        }

        Task<CategoryReadDto> IGenericService<CategoryCreateDto, CategoryReadDto, CategoryCreateDto>.GetByIdAsync(int id)//ELIMINAR
        {
            throw new NotImplementedException();
        }
    }
}
