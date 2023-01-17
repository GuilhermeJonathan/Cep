using Cep.Application.Read.DTOs.Bairros;
using Cep.Application.Read.Repositories;
using Cep.Infra.Data.Dapper.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cep.Infra.Data.Dapper
{
    public class BairroQuery : QueryBaseReadOnly, IBairroQuery
    {
        public BairroQuery(IConfiguration config) : base(config)
        {

        }

        public async Task<IEnumerable<BairroDTO>> GetAllByCidadeAsync(long idCidade)
        {
            var builder = CreateSqlBuilder(idCidade, out SqlBuilder.Template selector);

            var lista = await Connection.QueryAsync<BairroDTO>(
                $@"{selector.RawSql}", selector.Parameters);

            return lista;
        }

        private SqlBuilder CreateSqlBuilder(long idCidade, out SqlBuilder.Template selector)
        {
            var builder = new SqlBuilder();

            selector = builder.AddTemplate(@"
                            select 
                                BAIRRO_CODIGO id, 
                                BAIRRO_DESCRICAO descricao,                                
                                CIDADE_CODIGO CidadeId 
                            from BAIRRO B 
                            /**where**/ /**orderby**/");

            if (idCidade > 0)
                builder.Where(@"B.CIDADE_CODIGO = @idCidade", new { idCidade });

            builder.OrderBy(@"B.BAIRRO_DESCRICAO");

            return builder;
        }
    }
}
