using Cep.Application.Read.DTOs.Cidades;
using MediatR;
using System.Collections.Generic;

namespace Cep.Application.Read.Queries.Cidades
{
    public class GetCidadesQuery : IRequest<IEnumerable<CidadeDTO>>
    {
        public GetCidadesQuery(long estadoId)
        {
            IdEstado = estadoId;
        }

        public long IdEstado { get; set; }
    }
}
