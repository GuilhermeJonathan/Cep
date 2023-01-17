using Cep.Application.Read.DTOs.Pais;
using Cep.Application.Read.Queries.Paises;
using Cep.Application.Read.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cep.Application.Read.Handler.Paises
{
    internal class GetPaisesQueryHandler : IRequestHandler<GetPaisesQuery, IEnumerable<PaisDTO>>
    {
        private readonly IPaisQuery _paisQuery;

        public GetPaisesQueryHandler(IPaisQuery paisQuery)
        {
            _paisQuery = paisQuery;
        }

        public async Task<IEnumerable<PaisDTO>> Handle(GetPaisesQuery request, CancellationToken cancellationToken)
        {
            return await _paisQuery.GetAllAsync();
        }
    }
}
