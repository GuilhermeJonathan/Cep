using Cep.Application.Core;
using Cep.Application.Core.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cep.Api.Core.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        protected readonly NotificationDomainHandler _notifications;

        protected BaseController(INotificationHandler<NotificationDomain> notifications, IMediator handle)
        {
            _notifications = (NotificationDomainHandler)notifications;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public new IActionResult Response(object result = null)
        {
            if (OperacaoEhValida())
            {
                if (result != null && result.GetType() == typeof(CommandResult))
                {
                    var commandResult = (CommandResult)result;

                    if (commandResult.Data != null)
                        return Created("", commandResult.Data);
                    else
                        return NoContent();
                }
                else
                {
                    if (result == null)
                        return NotFound();
                    else
                    {
                        return Ok(result);
                    }
                }
            }
            else
            {
                return BadRequest(new CommandResult(_notifications.GetNotifications()));
            }
        }

        protected bool OperacaoEhValida()
        {
            return (!_notifications.HasNotifications());
        }
    }
}
