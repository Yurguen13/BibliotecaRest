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
using BibliotecaRest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Rest.Services.Services.Implementations
{
    public class PublisherService : IPublisherService
    {
        private readonly ApplicationDbContext _context;

        public PublisherService(ApplicationDbContext context)
        {
            _context = context;
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

        public async Task<bool> AddAsync(PublisherCreateDTO publisherDTO)
        {
            var publisher = new Publisher
            {
                Name = publisherDTO.Name,
                City = publisherDTO.City,
                Country = publisherDTO.Country,
                Phone = publisherDTO.Phone,
            };
            await _context.Publisher.AddAsync(publisher);
            await _context.SaveChangesAsync();
            publisher.Id = publisher.Id;

            return true;
        }

        public async Task<bool> UpdateAsync(int id, PublisherCreateDTO publisherDTO)
        {
            var publisher = await _context.Publisher
                .FindAsync(publisherDTO.Id);

            if(publisher == null)
                throw new ApplicationException(Messages.Error.PublisherNotFound);

            publisher.Name = publisherDTO.Name;
            publisher.City = publisherDTO.City;
            publisher.Country = publisherDTO.Country;
            publisher.Phone = publisherDTO.Phone;

            _context.Publisher.Update(publisher);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool>DeleteAsync(int id)
        {
            var publisher = await _context.Publisher
                .FindAsync(id);

            if(publisher == null)
                throw new ApplicationException(Messages.Error.PublisherNotFoundWithId);

            publisher.IsDeleted = true;
            _context.Publisher.Update(publisher);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
