using Cep.Application.Read.DTOs.Estados;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cep.Application.Read.Repositories
{
    public interface IEstadoQuery
    {
        Task<IEnumerable<EstadoDTO>> GetAllByPaisAsync(long idPais);
    }
}
