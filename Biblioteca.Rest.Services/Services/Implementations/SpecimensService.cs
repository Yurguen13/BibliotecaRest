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
    public class SpecimensService : ISpecimensService 
    {
        private readonly ApplicationDbContext _context;

        public SpecimensService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<SpecimensReadDTO>> GetAllAsync()
        {
            var specimens = await _context.Specimens
                .Where(s => !s.IsDeleted)
                .Select(s => new SpecimensReadDTO
                {
                    Id = s.Id,
                    Price = s.Price,
                    BooksId = s.BooksId,
                    Condition = s.Condition,
                    Observations = s.Observations
                })
                .ToListAsync();
            return specimens;
        }

        public async Task<SpecimensReadDTO>GetByIdAsync(int id)
        {
            var specimen = await _context.Specimens
                .Where(s => s.Id == id && !s.IsDeleted)
                .Select(s => new SpecimensReadDTO
                {
                    Id = s.Id,
                    Price = s.Price,
                    BooksId = s.BooksId,
                    Condition = s.Condition,
                    Observations = s.Observations
                })
                .FirstOrDefaultAsync();
                if(specimen == null)
                    throw new ApplicationException(string.Format(Messages.Error.SpecimenNotFoundWithId, id));
                return specimen;
        }

        public async Task<bool> AddAsync(SpecimensCreateDTO specimenDTO)
        {
            var specimen = new Specimens
            {
                Price = specimenDTO.Price,
                BooksId= specimenDTO.BooksId,
                Condition = specimenDTO.Condition,
                Observations = specimenDTO.Observations
            };
            await _context.Specimens.AddAsync(specimen);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id,  SpecimensCreateDTO specimenDTO)
        {
            var specimen = await _context.Specimens
               .FindAsync(specimenDTO.Id);

            if (specimen == null)
                throw new ApplicationException(Messages.Error.SpecimenNotFound);
                
                specimen.Price = specimenDTO.Price;
                specimen.BooksId = specimenDTO.BooksId;
                specimen.Condition = specimenDTO.Condition;
                specimen.Observations = specimenDTO.Observations;

            _context.Specimens.Update(specimen);
            await _context.SaveChangesAsync();

            return true;
            
        } 

        public async Task<bool>DeleteAsync(int id)
        {
            var specimen = await _context.Specimens
                .FindAsync(id);

            if (specimen == null)
                throw new ApplicationException(Messages.Error.SpecimentDeleteError);

            specimen.IsDeleted = true;
            _context.Specimens.Update(specimen);
            await _context.SaveChangesAsync();

            return true;
        }


    }
}
