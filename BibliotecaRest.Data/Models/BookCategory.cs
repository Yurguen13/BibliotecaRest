using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaRest.Data.Models
{
    public class BookCategory : Registry
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public int BooksId { get; set; }

        public Category Category { get; set; }
        public Books Books { get; set; }
    }
}
