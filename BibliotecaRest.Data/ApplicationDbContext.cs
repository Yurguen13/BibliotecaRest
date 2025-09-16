using BibliotecaRest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaRest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Autor> Autors {  get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Classification> Classifications { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Registry> Registries {  get; set; }
    }
}
