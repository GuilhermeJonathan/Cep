using Cep.Application.Read.DTOs.Bairros;
using Cep.Application.Read.DTOs.Cep;
using Cep.Application.Read.DTOs.Cidades;
using Cep.Application.Read.DTOs.Estados;
using Cep.Application.Read.DTOs.Pais;
using Cep.Application.Read.Repositories;
using Cep.Infra.Data.Dapper.Repositories.Base;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cep.Infra.Data.Dapper
{
    internal class EnderecoQuery : QueryBaseReadOnly, IEnderecoQuery
    {
        public EnderecoQuery(IConfiguration config) : base(config)
        {

        }

        public async Task<IEnumerable<EnderecoDTO>> GetByCepAsync(string cep)
        {
            var builder = CreateSqlBuilder(cep, out SqlBuilder.Template selector);

            var lista = await Connection.QueryAsync<EnderecoDTO, BairroDTO, CidadeDTO,
                EstadoDTO, PaisDTO, EnderecoDTO>(
               $@"{selector.RawSql}",
               (_endereco, _bairro, _cidade, _estado, _pais) =>
               {
                   if (_endereco != null)
                   {
                       _endereco.Bairro = _bairro;
                       _endereco.Bairro.Cidade = _cidade;
                       _endereco.Bairro.Cidade.Estado = _estado;
                       _endereco.Bairro.Cidade.Estado.Pais = _pais;                       
                   }

                   return _endereco;
               },
               selector.Parameters, splitOn: "Id, Id, Id");

            return lista;
        }

        private SqlBuilder CreateSqlBuilder(string cep, out SqlBuilder.Template selector)
        {
            var builder = new SqlBuilder();

            selector = builder.AddTemplate(@"
                            select 
                                E.ENDERECO_CODIGO Id, 
                                E.ENDERECO_CEP Cep, 
                                E.ENDERECO_LOGRADOURO Logradouro, 
                                E.ENDERECO_COMPLEMENTO Complemento,
                                E.ENDERECO_LATITUDE Latitude,
                                E.ENDERECO_LONGITUDE Longitude,
                                E.BAIRRO_CODIGO BairroId,
                                b.BAIRRO_CODIGO Id, b.CIDADE_CODIGO CidadeId, b.bairro_descricao Descricao,
                                c.CIDADE_CODIGO Id, c.UF_CODIGO EstadoId, c.cidade_descricao Descricao, 
                                u.UF_CODIGO Id, u.UF_SIGLA Sigla, u.UF_PAIS PaisId, u.UF_descricao Descricao,
                                p.PA_CODIGO Id, p.PA_DESCRICAO Descricao, p.PA_SIGLA Sigla, p.PA_DDI Ddi
                            from ENDERECO E   
                            left join bairro b on b.bairro_codigo = e.bairro_codigo 
                            left join cidade c on c.cidade_codigo = b.cidade_codigo 
                            left join uf u on u.uf_codigo = c.uf_codigo 
                            left join pais p on p.pa_codigo = u.uf_pais 
                            /**where**/ /**orderby**/");

            if (!String.IsNullOrEmpty(cep))
                builder.Where(@"E.ENDERECO_CEP = @cep", new { cep });

            return builder;
        }
    }
}
