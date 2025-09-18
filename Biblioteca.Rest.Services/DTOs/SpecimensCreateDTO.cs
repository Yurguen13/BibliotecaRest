using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Rest.Services.DTOs
{
    public class SpecimensCreateDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage="El precio es requerido")]
        [Range(50, double.MaxValue, ErrorMessage ="El precio debe ser mayor a 50")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Se debe ingresar un libro")]
        public int BooksId { get; set; }

        [Required(ErrorMessage ="La condicion del libro es requerida")]
        public string Condition { get; set; }
        public string Observations { get; set; }
    }
}
