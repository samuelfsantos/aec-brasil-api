using Aec.Brasil.Domain.Common.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Aec.Brasil.Api.Controllers
{
    [ApiController]
    public class ControllerBaseCustom : ControllerBase
    {
        protected readonly ILogger _logger;
        protected readonly INotificationDomain<NotificationDomainMessage> _notifications;
        protected readonly IMediator _mediator;

        protected ControllerBaseCustom(
            ILogger logger,
            INotificationDomain<NotificationDomainMessage> notifications,
            IMediator mediator)
        {
            _notifications = notifications;
            _logger = logger;
            _mediator = mediator;
        }

        protected bool IsSuccess
        {
            get
            {
                return (!_notifications.HasNotifications());
            }
        }

        protected IActionResult CustomResponse(object result = null)
        {
            if (IsSuccess)
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifications.GetAll().Select(n => n.Message)
            });
        }

        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notifications.Add(new NotificationDomainMessage(mensagem));
        }

        protected void ValidarEntradasOpcionais(params string[] args)
        {
            foreach (var entrada in args)
            {
                if (string.IsNullOrWhiteSpace(entrada)) continue;

                ValidarEntradas(entrada);

                if (!IsSuccess) return;
            }
        }

        protected void ValidarEntradas(params string[] args)
        {
            foreach (var entrada in args)
            {
                if (string.IsNullOrWhiteSpace(entrada))
                {
                    NotificarErro("Entrada inválida: ''");

                    return;
                };

                var guids = entrada.Trim().Split(',');

                var objGuidValid = Guid.Empty;

                foreach (var guid in guids)
                {
                    if (!Guid.TryParse(guid, out objGuidValid))
                    {
                        NotificarErro(string.Format("Entrada inválida: '{0}'", guid));

                        return;
                    };
                }
            }
        }

        protected Guid EntradaToGuid(string entrada)
        {
            if (!string.IsNullOrWhiteSpace(entrada))
                return new Guid(entrada);
            else
                return Guid.Empty;
        }
        protected Guid[] EntradaToGuidArray(string entrada)
        {
            if (!string.IsNullOrWhiteSpace(entrada))
                return entrada.Split(',').Select(x => new Guid(x)).ToArray();
            else
                return new Guid[] { };
        }
    }
}