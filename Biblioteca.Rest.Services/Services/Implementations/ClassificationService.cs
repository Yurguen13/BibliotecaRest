using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Rest.Services.Services.Interfaces;
using BibliotecaRest.Data.Data;

namespace Biblioteca.Rest.Services.Services.Implementations
{
    public class ClassificationService : IClassificationService
    {
        private readonly ApplicationDbContext _context;

        public ClassificationService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
