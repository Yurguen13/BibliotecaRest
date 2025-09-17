using Biblioteca.Rest.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Rest.Services.Services.Interfaces
{
    public interface IBookService : IGenericService<BookCreateDto,BookReadDto,BookCreateDto>
    {
    }
}
