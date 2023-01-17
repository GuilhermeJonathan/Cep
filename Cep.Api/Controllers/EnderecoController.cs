using Cep.Api.Config;
using Cep.Application.Core.Notification;
using Cep.Application.Read.Queries.Bairros;
using Cep.Application.Read.Queries.Ceps;
using Cep.Application.Read.Queries.Cidades;
using Cep.Application.Read.Queries.Estados;
using Cep.Application.Read.Queries.Paises;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cep.Api.Controllers
{
    [Route("api/endereco")]
    public class EnderecoController : BaseApiController
    {
        private readonly IMediator _handle;

        public EnderecoController
        (
            INotificationHandler<NotificationDomain> notifications,
            IMediator handle,
            INotifier notifier
        ) : base(notifications, handle, notifier)
        {
            _handle = handle;
        }

        /// <summary>
        /// Retorna Países
        /// </summary>        
        /// <returns></returns>
        [HttpGet("paises")]
        public async Task<IActionResult> GetPaises()
        {
            return Response(await _handle.Send(new GetPaisesQuery()));
        }

        /// <summary>
        /// Retorna Estados por País
        /// </summary>
        /// <param name="idPais">IdEstado</param>
        /// <returns></returns>
        [HttpGet("estados/{idPais}")]
        public async Task<IActionResult> GetEstados(long idPais)
        {
            return Response(await _handle.Send(new GetEstadosQuery(idPais)));
        }

        /// <summary>
        /// Retorna Cidades por Estado
        /// </summary>
        /// <param name="idEstado">IdEstado</param>
        /// <returns>CidadeDTO</returns>
        [HttpGet("cidades/{idEstado}")]
        public async Task<IActionResult> GetCidades(long idEstado)
        {
            return Response(await _handle.Send(new GetCidadesQuery(idEstado)));
        }

        /// <summary>
        /// Retorna Bairro por Cidade
        /// </summary>
        /// <param name="idCidade">IdCidade</param>
        /// <returns>BairroDTO</returns>
        [HttpGet("cidades/bairros/{idCidade}")]
        public async Task<IActionResult> GetBairros(long idCidade)
        {
            return Response(await _handle.Send(new GetBairrosQuery(idCidade)));
        }

        /// <summary>
        /// Retorna busca por CEP
        /// </summary>
        /// <param name="cep">IdEstado</param>
        /// <returns></returns>
        [HttpGet("cep/{cep}")]
        public async Task<IActionResult> GetByCep(string cep)
        {
            return Response(await _handle.Send(new GetCepQuery(cep)));
        }
    }
}
