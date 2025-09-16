using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaRest.Data.Models
{
    public class Reader : Registry
    {

        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(10)]
        public string Phono { get; set; }
        [MaxLength(100)]

        public string Email { get; set; }
        [MaxLength(120)]
        public string City { get; set; }

        public ICollection<Loans> Loans { get; set; } = new List<Loans>();
    }
}
