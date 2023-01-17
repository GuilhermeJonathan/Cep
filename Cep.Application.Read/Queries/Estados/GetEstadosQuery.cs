using Cep.Application.Read.DTOs.Estados;
using MediatR;
using System.Collections.Generic;

namespace Cep.Application.Read.Queries.Estados
{
    public class GetEstadosQuery : IRequest<IEnumerable<EstadoDTO>>
    {
        public GetEstadosQuery(long idPais)
        {
            PaisId = idPais;
        }

        public long PaisId { get; set; }
    }
}
