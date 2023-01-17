using Cep.Application.Read.DTOs.Cidades;
using Cep.Application.Read.Queries.Cidades;
using Cep.Application.Read.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cep.Application.Read.Handler.Cidades
{
    internal class GetCidadesQueryHandler : IRequestHandler<GetCidadesQuery, IEnumerable<CidadeDTO>>
    {
        private readonly ICidadeQuery _cidadeQuery;

        public GetCidadesQueryHandler(ICidadeQuery cidadeQuery)
        {
            _cidadeQuery = cidadeQuery;
        }

        public async Task<IEnumerable<CidadeDTO>> Handle(GetCidadesQuery request, CancellationToken cancellationToken)
        {
            return await _cidadeQuery.GetAllByEstadoAsync(request.IdEstado);
        }
    }
}
