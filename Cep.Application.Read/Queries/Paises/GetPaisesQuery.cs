using Cep.Application.Read.DTOs.Pais;
using MediatR;
using System.Collections.Generic;

namespace Cep.Application.Read.Queries.Paises
{
    public class GetPaisesQuery : IRequest<IEnumerable<PaisDTO>>
    {
    }
}
