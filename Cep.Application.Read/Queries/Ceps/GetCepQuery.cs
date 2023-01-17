using Cep.Application.Read.DTOs.Cep;
using MediatR;
using System.Collections.Generic;

namespace Cep.Application.Read.Queries.Ceps
{
    public class GetCepQuery : IRequest<IEnumerable<EnderecoDTO>>
    {
        public GetCepQuery(string cep)
        {
            Cep = cep;
        }

        public string Cep { get; set; }
    }
}
