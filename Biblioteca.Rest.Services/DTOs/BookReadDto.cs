using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Rest.Services.DTOs
{
    public class BookReadDto : RegistryDTO
    {
        public int Id { get; set; }

      
        
        public string Name { get; set; }


        public string Language { get; set; }

        public int Year { get; set; }
        public int PublisherId { get; set; }
        public int ClassificationId { get; set; }

        public string Publisher { get; set; }
        public string Classification { get; set; }
    }
}
