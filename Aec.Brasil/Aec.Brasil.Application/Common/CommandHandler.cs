using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using Aec.Brasil.Domain.Common;
using Aec.Brasil.Domain.Common.Notification;

namespace Aec.Brasil.Application
{
    public abstract class CommandHandler
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMediator _mediator;
        protected readonly INotificationDomain<NotificationDomainMessage> _notifications;
        protected readonly ILogger _logger;

        public CommandHandler(IUnitOfWork uow,
            IMediator mediator,
            INotificationDomain<NotificationDomainMessage> notifications)
        {
            _uow = uow;
            _mediator = mediator;
            _notifications = notifications;
        }

        public CommandHandler(IUnitOfWork uow, IMediator mediator,
            INotificationDomain<NotificationDomainMessage> notifications,
            ILogger logger = null)
        {
            _uow = uow;
            _mediator = mediator;
            _notifications = notifications;
            _logger = logger;
        }

        protected void NotificarErros(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _notifications.Add(new NotificationDomainMessage(error.ErrorMessage));
            }
        }

        protected bool IsSuccess()
        {
            return !_notifications.HasNotifications();
        }

        public void AddDomainNotification(string message)
        {
            _notifications.Add(new NotificationDomainMessage(message));
        }

        protected bool Commit()
        {
            if (_logger != null) _logger.LogTrace("Domain Notification IsSuccess", IsSuccess());
            if (!IsSuccess()) return false;
            var isCommit = _uow.Commit();
            if (isCommit) return true;
            var error = "Ocorreu um erro ao salvar os dados no banco de dados";
            AddDomainNotification(error);
            if (_logger != null) _logger.LogTrace(error);
            return false;
        }
    }
}
