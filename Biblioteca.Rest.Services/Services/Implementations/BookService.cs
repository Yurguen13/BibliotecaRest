using Biblioteca.Rest.Services.Constants;
using Biblioteca.Rest.Services.DTOs;
using Biblioteca.Rest.Services.Services.Interfaces;
using BibliotecaRest.Data.Data;
using BibliotecaRest.Data.Models;
using EcommerRest.Services.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;


using Microsoft.AspNetCore.Http;

namespace Biblioteca.Rest.Services.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;
        public readonly IWebHostEnvironment _env;
        public readonly UploadSettings _uploadSettings;

        public BookService(ApplicationDbContext context,
            IWebHostEnvironment env,
            UploadSettings uploadSettings
            )
        {
            _context = context;
            _env = env;
            _uploadSettings = uploadSettings;
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
                       PublisherId=x.PublisherId,
                       ClassificationId=x.ClassificationId,
                       path=x.path !=null  ? x.path : "",

                       Active = x.Active

                   }).FirstOrDefaultAsync();

            return books;
        }

        private async Task<string> UploadImage(IFormFile file)
        {
            ValidateFile(file);

            string _customPath = Path.Combine(Directory.GetCurrentDirectory(), _uploadSettings.UploadDirectory);
            //    string _customPath = Path.Combine(_env.WebRootPath, uploadSettings.UploadDirectory);

            if (!Directory.Exists(_customPath))   // Crear el directorio si no existe
            {
                Directory.CreateDirectory(_customPath);
            }

            // Generar el nombre único del archivo
            var fileName = Path.GetFileNameWithoutExtension(file.FileName)
                            + Guid.NewGuid().ToString()
                            + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_customPath, fileName);

            // Guardar el archivo
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Retornar la ruta relativa o completa, según sea necesario
            return $"/{_uploadSettings.UploadDirectory}/{fileName}";
        }


        private void ValidateFile(IFormFile file)
        {
            var permittedExtensions = _uploadSettings.AllowedExtensions.Split(',');
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!permittedExtensions.Contains(extension))
            {
                //throw new NotSupportedException("El tipo de archivo no es soportado.");
                //   throw new NotSupportedException(Messages.Validation.UnSupportedFileType);
            }
        }
        public async Task<bool> AddAsync(BookCreateDto books)
        {
            Books boo = new Books();
            if (books.file!=null)
            {
                var urlImagen = await UploadImage(books.file);
                boo.path = urlImagen;
            }
          
            try
            {
              
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

            if (books.file != null)
            {
                var urlImagen = await UploadImage(books.file);

                book.path = urlImagen;
            }

       

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
