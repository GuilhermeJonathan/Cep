using Cep.Application.Read.DTOs.Bairros;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cep.Application.Read.Repositories
{
    public interface IBairroQuery
    {
        Task<IEnumerable<BairroDTO>> GetAllByCidadeAsync(long idCidade);
    }
}
