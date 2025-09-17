using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Rest.Services.DTOs
{
    public class AuthorReadDto : RegistryDTO
    {
        public int Id { get; set; }
    
        public string Name { get; set; }
     
        public string LastName { get; set; }
     
        public string Email { get; set; }
     

        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
    }
}
