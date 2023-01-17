using Cep.Application.Read.DTOs.Cep;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cep.Application.Read.Repositories
{
    public interface IEnderecoQuery
    {
        Task<IEnumerable<EnderecoDTO>> GetByCepAsync(string cep);
    }
}
