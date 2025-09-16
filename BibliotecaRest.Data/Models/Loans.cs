using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaRest.Data.Models
{
    public class Loans : Registry
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public int  ReaderId { get; set; }
        public int SpecimensId { get; set; }
        public Reader Reader { get; set; }
        public Specimens Specimens { get; set; }    
    }
}
