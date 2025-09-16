using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Rest.Services.DTOs;
using Biblioteca.Rest.Services.Services.Interfaces;
using BibliotecaRest.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Rest.Services.Services.Implementations
{
    /*
    public class ClassificationService : IClassificationService
    {
        private readonly ApplicationDbContext _context;

        public ClassificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClassificationReadDTO>> GetAllAsync()
        {
           var classifications = await _context.Classifications
                .Where(c => !c.IsDeleted)
                .Select(c => new ClassificationReadDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Code = c.Code,
                })
                .ToListAsync();
            return classifications;
        }

        public async Task<ClassificationReadDTO> GetByIdAsync(int id)
        {
            var classification = await _context.Classifications
                .Where(c => c.Id == id && !c.IsDeleted)
                .Select(c => new ClassificationReadDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Code = c.Code,
                })
                .FirstOrDefaultAsync();
            if(classification == null)
                throw new ApplicationException(string.Format(Messages.Error.ProductNotFoundWithId, id));

            return classification;
        }

    }*/
}
