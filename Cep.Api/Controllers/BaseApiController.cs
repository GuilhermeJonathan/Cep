using Cep.Api.Config;
using Cep.Api.Core.Controllers;
using Cep.Application.Core;
using Cep.Application.Core.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace Cep.Api.Controllers
{
    public class BaseApiController : BaseController
    {
        private readonly IMediator _handle;
        private readonly INotifier _notifier;

        protected BaseApiController(INotificationHandler<NotificationDomain> notifications, IMediator handle, INotifier notifier) : base(notifications, handle)
        {
            _handle = handle;
            _notifier = notifier;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected ActionResult Response(object result = null)
        {
            if (this.OperacaoEhValida())
            {
                if (result is CommandResult commandResult)
                {
                    var customResult = new
                    {
                        success = commandResult.Success,
                        message = string.IsNullOrEmpty(commandResult.Message) ? null : new[] { commandResult.Message },
                        data = commandResult.Data
                    };
                    return Ok(customResult);
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = _notifications.GetNotifications().Select(n => n.Message)
                });
            }
            return result == null ? NotFound() : Ok(result);
        }

        protected ActionResult Response(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifierErrorInvalidModel(modelState);
            return Response();
        }

        protected void NotifierErrorInvalidModel(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                ErrorNotifier(errorMessage);
            }
        }

        protected void ErrorNotifier(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool IsValid()
        {
            return !_notifier.HasNotification();
        }
    }
}
