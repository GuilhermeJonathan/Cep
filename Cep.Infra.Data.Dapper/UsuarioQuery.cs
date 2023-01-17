using Default.Application.Read.Repositories;
using Default.Infra.Data.Dapper.Repositories.Base;
using Microsoft.Extensions.Configuration;

namespace Default.Infra.Data.Dapper
{
    public class UsuarioQuery : QueryBaseReadOnly, IUsuarioQuery
    {
        public UsuarioQuery(IConfiguration config) : base(config)
        {
        }
    }
}
