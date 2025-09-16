using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Rest.Services.DTOs
{
    public class RegistryDTO
    {
        public bool Active { get; set; } = true;
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
