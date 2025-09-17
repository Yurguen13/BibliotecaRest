using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Rest.Services.DTOs
{
    public  class AuthorCreateDto : RegistryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Los apellidos son requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]

        public DateTime Birthdate { get; set; }
        
        public string Phone { get; set; }
    }
}
