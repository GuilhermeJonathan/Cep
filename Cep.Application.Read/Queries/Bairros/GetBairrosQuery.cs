using Cep.Application.Read.DTOs.Bairros;
using MediatR;
using System.Collections.Generic;

namespace Cep.Application.Read.Queries.Bairros
{
    public class GetBairrosQuery : IRequest<IEnumerable<BairroDTO>>
    {
        public GetBairrosQuery(long cidadeId)
        {
            IdCidade = cidadeId;
        }

        public long IdCidade { get; set; }
    }
}
