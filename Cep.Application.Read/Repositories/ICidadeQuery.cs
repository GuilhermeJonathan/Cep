using Cep.Application.Read.DTOs.Cidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cep.Application.Read.Repositories
{
    public interface ICidadeQuery
    {
        Task<IEnumerable<CidadeDTO>> GetAllByEstadoAsync(long idEstado);
    }
}
