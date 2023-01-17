using Cep.Application.Read.Repositories;
using Cep.Infra.Data.Dapper.Repositories.Base;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Cep.Application.Read.DTOs.Estados;
using Dapper;

namespace Cep.Infra.Data.Dapper
{
    public class EstadoQuery : QueryBaseReadOnly, IEstadoQuery
    {
        public EstadoQuery(IConfiguration config) : base(config)
        {

        }

        public async Task<IEnumerable<EstadoDTO>> GetAllByPaisAsync(long idPais)
        {
            var builder = CreateSqlBuilder(idPais, out SqlBuilder.Template selector);

            var lista = await Connection.QueryAsync<EstadoDTO>(
                $@"{selector.RawSql}", selector.Parameters);

            return lista;
        }

        private SqlBuilder CreateSqlBuilder(long idPais, out SqlBuilder.Template selector)
        {
            var builder = new SqlBuilder();

            selector = builder.AddTemplate(@"
                            select 
                                U.UF_CODIGO Id, 
                                U.UF_SIGLA Sigla, 
                                U.UF_DESCRICAO Descricao,
                                U.UF_PAIS PaisId 
                            from uf u                            
                            /**where**/ /**orderby**/");

            if (idPais > 0)
                builder.Where(@"u.UF_PAIS = @idPais", new { idPais });
            
            builder.OrderBy(@"u.uf_sigla");

            return builder;
        }
    }
}
