using BibliotecaRest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaRest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Author> Authors {  get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Books> Books { get; set; } //check the plural
        public DbSet<Category> Categories { get; set; }
        public DbSet<Loans> Loans {  get; set; } //check the plural
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Reader> Readers { get; set; } 
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Specimens> Specimens { get; set; }//check the plural

    }
}
