using BibliotecaRest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaRest.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Author> Autors {  get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Reader> Readers { get; set; }
        
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<Specimens> Specimens { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Books> Books { get; set; }
        
    }
}

