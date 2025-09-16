using BibliotecaRest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaRest.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

<<<<<<< HEAD:BibliotecaRest.Data/Data/ApplicationDbContext.cs
        public DbSet<Author> Autors {  get; set; }
=======
        public DbSet<Author> Authors {  get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Books> Books { get; set; } //check the plural
>>>>>>> 468690bfe58b3a977dbf39335b36381bd2de794a:BibliotecaRest.Data/ApplicationDbContext.cs
        public DbSet<Category> Categories { get; set; }
        public DbSet<Loans> Loans {  get; set; } //check the plural
        public DbSet<Publisher> Publishers { get; set; }
<<<<<<< HEAD:BibliotecaRest.Data/Data/ApplicationDbContext.cs
        public DbSet<Reader> Readers { get; set; }
        
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<Specimens> Specimens { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<Books> Books { get; set; }
        
=======
        public DbSet<Reader> Readers { get; set; } 
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Specimens> Specimens { get; set; }//check the plural

>>>>>>> 468690bfe58b3a977dbf39335b36381bd2de794a:BibliotecaRest.Data/ApplicationDbContext.cs
    }
}

