using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Rest.Services.Services.Interfaces
{
    public interface IGenericService<TCreatDto,TReadDto,TUpdateDto>
        where TCreatDto :class
        where TUpdateDto :class
        where TReadDto : class
    {

        Task<ICollection<TReadDto>> GetAllAsync();
        Task<TReadDto> GetByIdAsync(int id);
        Task AddAsync(TCreatDto creatDto);
        Task UpdateAsync(int id, TCreatDto tcreatDto);
        Task DeleteAsync(int id);

      

    }
}
