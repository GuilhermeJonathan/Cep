using Cep.Application.Read.DTOs.Estados;
using Cep.Application.Read.Queries.Estados;
using Cep.Application.Read.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cep.Application.Read.Handler.Estados
{
    internal class GetEstadosQueryHandler : IRequestHandler<GetEstadosQuery, IEnumerable<EstadoDTO>>
    {
        private readonly IEstadoQuery _estadoQuery;

        public GetEstadosQueryHandler(IEstadoQuery estadoQuery)
        {
            _estadoQuery = estadoQuery;
        }

        public async Task<IEnumerable<EstadoDTO>> Handle(GetEstadosQuery request, CancellationToken cancellationToken)
        {
            return await _estadoQuery.GetAllByPaisAsync(request.PaisId);
        }
    }
}
