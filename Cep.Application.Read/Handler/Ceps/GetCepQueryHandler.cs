using Cep.Application.Read.DTOs.Cep;
using Cep.Application.Read.Queries.Ceps;
using Cep.Application.Read.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cep.Application.Read.Handler.Ceps
{
    internal class GetCepQueryHandler : IRequestHandler<GetCepQuery, IEnumerable<EnderecoDTO>>
    {
        private readonly IEnderecoQuery _enderecoQuery;

        public GetCepQueryHandler(IEnderecoQuery enderecoQuery)
        {
            _enderecoQuery = enderecoQuery;
        }

        public async Task<IEnumerable<EnderecoDTO>> Handle(GetCepQuery request, CancellationToken cancellationToken)
        {
            return await _enderecoQuery.GetByCepAsync(request.Cep);
        }
    }
}
