using Biblioteca.Rest.Services.Constants;
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
    public class AuthorService : IAuthosService
    {
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<AuthorReadDto>> GetAllAsync()
        {

            var author = await _context.Authors
                   .Where(x => !x.IsDeleted && x.Active)
                   .Select(x => new AuthorReadDto
                   {
                       Id = x.Id,
                       Name = x.Name,
                       LastName = x.LastName,
                       Birthdate=x.Birthdate,
                       Email=x.Email,
                       Phone=x.Phone,
                       Active=x.Active

                   }).ToListAsync();

            return author;

        }

        public async Task<AuthorReadDto> GetByIdAsync(int id)
        {
            var author = await _context.Authors
                   .Where(x => x.Id == id && !x.IsDeleted && x.Active)
                   .Select(x => new AuthorReadDto
                   {
                       Id = x.Id,
                       Name = x.Name,
                       LastName = x.LastName,
                       Email = x.Email,
                       Birthdate = x.Birthdate,
                       Phone = x.Phone,
                       Active = x.Active

                   }).FirstOrDefaultAsync();

            return author;
        }

        public async Task<bool> AddAsync(AuthorCreateDto authors)
        {
            try
            {
                Author author = new Author();
                //  cate.Id = category.Id;
                author.Name = authors.Name;
                author.LastName = authors.LastName;
                author.Email = authors.Email;
                author.Birthdate = authors.Birthdate;
                author.Phone = authors.Phone;
                
                  

                await _context.Authors.AddAsync(author);
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public async Task<bool> UpdateAsync(int id, AuthorCreateDto author)
        {
            var authors = await _context.Authors.FindAsync(id);

            if (authors == null)
            {
                return false;
            }
            authors.Name = author.Name;
            authors.LastName = author.LastName;
            authors.Email = author.Email;
            authors.Birthdate = author.Birthdate;
            await _context.SaveChangesAsync();

            return true;


        }



        public async Task<bool> DeleteAsync(int id)
        {

            try
            {
                var author = await _context.Authors
            .FindAsync(id);
                if (author == null)
                    throw new Exception(Messages.Error.AuthorNotFound);

                author.IsDeleted = true;
                author.Active = false;
                await _context.SaveChangesAsync();


                return true;

            }
            catch (Exception ex)
            {
                return false;
            }





        }

       

      
    }
}
