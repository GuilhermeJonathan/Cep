using Cep.Application.Read.DTOs.Cidades;
using Cep.Application.Read.Repositories;
using Cep.Infra.Data.Dapper.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cep.Infra.Data.Dapper
{
    public class CidadeQuery : QueryBaseReadOnly, ICidadeQuery
    {
        public CidadeQuery(IConfiguration config) : base(config)
        {

        }

        public async Task<IEnumerable<CidadeDTO>> GetAllByEstadoAsync(long idEstado)
        {
            var builder = CreateSqlBuilder(idEstado, out SqlBuilder.Template selector);

            var lista = await Connection.QueryAsync<CidadeDTO>(
                $@"{selector.RawSql}", selector.Parameters);

            return lista;
        }

        private SqlBuilder CreateSqlBuilder(long idEstado, out SqlBuilder.Template selector)
        {
            var builder = new SqlBuilder();

            selector = builder.AddTemplate(@"
                            select 
                                CIDADE_CODIGO id, 
                                CIDADE_DESCRICAO descricao,
                                CIDADE_CEP cep, 
                                UF_CODIGO EstadoId 
                            from cidade C 
                            /**where**/ /**orderby**/");

            if (idEstado > 0)
                builder.Where(@"C.UF_CODIGO = @idEstado", new { idEstado });

            builder.OrderBy(@"C.CIDADE_DESCRICAO");

            return builder;
        }
    }
}
