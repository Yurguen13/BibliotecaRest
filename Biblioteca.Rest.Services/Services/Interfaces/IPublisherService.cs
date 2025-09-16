using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Rest.Services.DTOs;

namespace Biblioteca.Rest.Services.Services.Interfaces
{
    public interface IPublisherService : IGenericService<PublisherCreateDTO, PublisherReadDTO, PublisherCreateDTO>
    {

    }
}
