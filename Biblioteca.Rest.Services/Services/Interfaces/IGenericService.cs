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
        Task<bool> AddAsync(TCreatDto creatDto);
        Task<bool> UpdateAsync(int id, TCreatDto tcreatDto);
        Task<bool> DeleteAsync(int id);

      

    }
}
