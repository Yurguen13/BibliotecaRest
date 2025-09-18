using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Rest.Services.DTOs
{
    public class ClassificationCreateDTO : RegistryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Name { get; set; }

        [Required(ErrorMessage ="La descripcion es requerida")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El codigo es requerido")]
        public string Code { get; set; }
    }
}
