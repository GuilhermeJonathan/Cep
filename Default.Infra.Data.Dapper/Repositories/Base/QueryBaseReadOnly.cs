using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace Default.Infra.Data.Dapper.Repositories.Base
{
    public abstract class QueryBaseReadOnly
    {
        private readonly IConfiguration _config;

        protected QueryBaseReadOnly(IConfiguration config)
        {
            _config = config;
        }

        //public IDbConnection Connection => new OracleConnection(_config.GetConnectionString("DefaultConnection"));
    }
}
