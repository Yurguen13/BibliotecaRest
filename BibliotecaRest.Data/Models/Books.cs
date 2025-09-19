using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaRest.Data.Models
{
    public class Books : Registry
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Language { get; set; }

        public int Year { get; set; }
        public int PublisherId { get; set; }
        public int ClassificationId { get; set; } 

        public string path { get; set; }

        public Classification Classification { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();

        public ICollection<BookAuthor> BookAuthor { get; set; } = new HashSet<BookAuthor>();
        public ICollection<Specimens> Specimens { get; set; } = new HashSet<Specimens>();




    }
}
