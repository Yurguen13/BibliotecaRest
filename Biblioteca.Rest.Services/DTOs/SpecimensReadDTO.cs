using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaRest.Data.Models;

namespace Biblioteca.Rest.Services.DTOs
{
    public class SpecimensReadDTO : RegistryDTO
    {
        public int Id { get; set; }
        public Decimal Price { get; set; }
        public int BooksId { get; set; }
        public string Condition { get; set; }
        public string Observations { get; set; }
        public string Books { get; set; }
    }
}
