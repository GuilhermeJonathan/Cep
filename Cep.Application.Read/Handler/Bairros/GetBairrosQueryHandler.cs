using Cep.Application.Read.DTOs.Bairros;
using Cep.Application.Read.Queries.Bairros;
using Cep.Application.Read.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cep.Application.Read.Handler.Bairros
{
    internal class GetBairrosQueryHandler : IRequestHandler<GetBairrosQuery, IEnumerable<BairroDTO>>
    {
        private readonly IBairroQuery _bairroQuery;

        public GetBairrosQueryHandler(IBairroQuery bairroQuery)
        {
            _bairroQuery = bairroQuery;
        }

        public async Task<IEnumerable<BairroDTO>> Handle(GetBairrosQuery request, CancellationToken cancellationToken)
        {
            return await _bairroQuery.GetAllByCidadeAsync(request.IdCidade);
        }
    }
}
