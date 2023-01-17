using Cep.Application.Read.Repositories;
using Cep.Infra.Data.Dapper.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Cep.Infra.Data.Dapper
{
    public class UsuarioQuery : QueryBaseReadOnly, IUsuarioQuery
    {
        public UsuarioQuery(IConfiguration config) : base(config)
        {
        }
    }
}
