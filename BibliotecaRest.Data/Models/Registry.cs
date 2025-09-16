using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaRest.Data.Models
{
    // con se soluciona para que no lo mapee
    [NotMapped]
    public class Registry
    {
        public bool Active { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
