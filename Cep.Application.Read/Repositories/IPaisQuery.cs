using Cep.Application.Read.DTOs.Pais;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cep.Application.Read.Repositories
{
    public interface IPaisQuery
    {
        Task<IEnumerable<PaisDTO>> GetAllAsync();
    }
}
