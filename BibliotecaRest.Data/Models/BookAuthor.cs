using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaRest.Data.Models
{
    public class BookAuthor : Registry
    {
        public int Id { get; set; } 
        public int AuthorId { get; set; }
        public int BooksId { get; set; }    

        public Books Books { get; set; }

        public Author Author { get; set; }  
    }
}
