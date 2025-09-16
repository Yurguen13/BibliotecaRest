using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Rest.Services.Constants;
using Biblioteca.Rest.Services.DTOs;
using Biblioteca.Rest.Services.Services.Interfaces;
using BibliotecaRest.Data.Data;
using BibliotecaRest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Rest.Services.Services.Implementations
{
    
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
                throw new ApplicationException(string.Format(Messages.Error.ClassificationNotFoundWithId, id));

            return classification;
        }

        public async Task AddAsync(ClassificationCreateDTO classificationDTO)
        {
            var classification = new Classification
            {
                Name = classificationDTO.Name,
                Description = classificationDTO.Description,
                Code = classificationDTO.Code,
            };
            await _context.Classifications.AddAsync(classification);
            await _context.SaveChangesAsync();
            classificationDTO.Id = classification.Id;
        } 

        public async Task UpdateAsync(ClassificationCreateDTO classificationDTO)
        {
            var classification = await _context.Classifications
                .FindAsync(classificationDTO.Id);

            if (classification == null)
                throw new ApplicationException(Messages.Error.ClassificationNotFound);

            classification.Name = classificationDTO.Name;
            classification.Description = classificationDTO.Description;
            classification.Code = classificationDTO.Code;


            _context.Classifications.Update(classification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var classification = await _context.Classifications
                .FindAsync(id);

            if (classification == null)
                throw new ApplicationException(Messages.Error.ClassificationNotFound);

            classification.Active = false;
            _context.Classifications.Update(classification);
            await _context.SaveChangesAsync();
        }

        Task<ICollection<ClassificationReadDTO>> IGenericService<ClassificationCreateDTO, ClassificationReadDTO, ClassificationCreateDTO>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, ClassificationCreateDTO tcreatDto)
        {
            throw new NotImplementedException();
        }
    }
}
