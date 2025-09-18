using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Rest.Services.DTOs
{
    public class PublisherCreateDTO : RegistryDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage="El nombre es requerido")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "La ciudad es requerida")]
        [MaxLength(100)]
        public string City { get; set; }

        [Required(ErrorMessage ="El pais es requerido")]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required(ErrorMessage ="El telefono es requerido")]
        [MaxLength(10)]
        public string Phone { get; set; }
    }
}
