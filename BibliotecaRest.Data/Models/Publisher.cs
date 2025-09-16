using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaRest.Data.Models
{
    public class Publisher : Registry
    { 
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; } 

        public ICollection<Books> Books { get; set; }

        
    }
}
