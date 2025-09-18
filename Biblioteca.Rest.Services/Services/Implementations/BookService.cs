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
    public  class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<BookReadDto>> GetAllAsync()
        {

            var books = await _context.Books
                   .Where(x => !x.IsDeleted && x.Active)
                   .Select(x => new BookReadDto
                   {
                       Id = x.Id,
                       Name = x.Name,
                       Language = x.Language,
                       Year = x.Year,
                       Publisher=x.Publisher.Name,
                       Classification=x.Classification.Name,
                       
                       Active = x.Active

                   }).ToListAsync();

            return books;

        }

        public async Task<BookReadDto> GetByIdAsync(int id)
        {
            var books = await _context.Books
                   .Where(x => x.Id == id && !x.IsDeleted && x.Active)
                   .Select(x => new BookReadDto
                   {

                       Id = x.Id,
                       Name = x.Name,
                       Language = x.Language,
                       Year = x.Year,
                       Publisher = x.Publisher.Name,
                       Classification = x.Classification.Name,

                       Active = x.Active

                   }).FirstOrDefaultAsync();

            return books;
        }

        public async Task<bool> AddAsync(BookCreateDto books)
        {
            try
            {
                Books boo = new Books();
                //  cate.Id = category.Id;
                boo.Name = books.Name;
                boo.Language = books.Language;
                boo.Year = books.Year;
                boo.ClassificationId = books.ClassificationId;
                boo.PublisherId = books.PublisherId;
                



                await _context.Books.AddAsync(boo);
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public async Task<bool> UpdateAsync(int id, BookCreateDto books)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return false;
            }
            book.Name = books.Name;
            book.Language = books.Language;
            book.Year = books.Year;
            book.PublisherId = books.PublisherId;
            book.ClassificationId = books.ClassificationId;
            await _context.SaveChangesAsync();

            return true;


        }



        public async Task<bool> DeleteAsync(int id)
        {

            try
            {
                var author = await _context.Books
            .FindAsync(id);
                if (author == null)
                    throw new Exception(Messages.Error.BooksNotFound);

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
