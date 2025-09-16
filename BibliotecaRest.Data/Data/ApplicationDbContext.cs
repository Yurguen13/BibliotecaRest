using BibliotecaRest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaRest.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Author> Authors {  get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        

        public DbSet<Reader> Readers { get; set; }
        
        
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<Specimens> Specimens { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Publisher> Publisher { get; set; }


    }
}

