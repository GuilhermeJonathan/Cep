using Cep.Application.Read.DTOs.Pais;
using Cep.Application.Read.Repositories;
using Cep.Infra.Data.Dapper.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cep.Infra.Data.Dapper
{
    public class PaisQuery : QueryBaseReadOnly, IPaisQuery
    {
        public PaisQuery(IConfiguration config) : base(config)
        {

        }

        public async Task<IEnumerable<PaisDTO>> GetAllAsync()
        {
            var builder = CreateSqlBuilder(out SqlBuilder.Template selector);

            var lista = await Connection.QueryAsync<PaisDTO>(
                $@"{selector.RawSql}", selector.Parameters);

            return lista;
        }

        private SqlBuilder CreateSqlBuilder(out SqlBuilder.Template selector)
        {
            var builder = new SqlBuilder();

            selector = builder.AddTemplate(@"
                            select 
                                P.PA_CODIGO Id, 
                                P.PA_SIGLA Sigla, 
                                P.PA_DESCRICAO Descricao,
                                P.PA_DDI Ddi 
                            from PAIS P                            
                            /**where**/ /**orderby**/");

            builder.OrderBy(@"P.PA_DESCRICAO");

            return builder;
        }
    }
}
