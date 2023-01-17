using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Cep.Infra.Data.Dapper.Repositories.Base
{
    public abstract class QueryBaseReadOnly
    {
        private readonly IConfiguration _config;

        protected QueryBaseReadOnly(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection => new SqlConnection(_config.GetConnectionString("DefaultConnection"));
    }
}
