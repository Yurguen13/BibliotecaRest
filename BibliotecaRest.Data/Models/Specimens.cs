using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaRest.Data.Models
{
    public class Specimens : Registry
    {
        public  int Id { get; set; }    
        public Decimal Price { get; set; }
        public int  BooksId { get; set; }
        public string Condition { get; set; }
        public string  Observations { get; set; }

        public Books Books { get; set; }

        public ICollection<Loans> Loans { get; set; } = new List<Loans>();
    }
}
