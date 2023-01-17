using Default.Api.Config;
using Default.Application.Core.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Default.Api.Controllers
{
    [Route("api/usuario")]
    public class UsuarioController : BaseApiController
    {
        private readonly IMediator _handle;

        public UsuarioController
        (
            INotificationHandler<NotificationDomain> notifications,
            IMediator handle,
            INotifier notifier
        ) : base(notifications, handle, notifier)
        {
            _handle = handle;
        }
    }
}
