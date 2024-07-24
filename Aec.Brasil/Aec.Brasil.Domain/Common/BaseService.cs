using Aec.Brasil.Domain.Common.Notification;
using FluentValidation.Results;

namespace Aec.Brasil.Domain.Common
{
    public abstract class BaseService
    {
        private readonly INotificationDomain<NotificationDomainMessage> _notification;

        public BaseService(INotificationDomain<NotificationDomainMessage> notification)
        {
            _notification = notification;
        }

        public void AddDomainNotification(string message)
        {
            _notification.Add(new NotificationDomainMessage(message));
        }

        public void AddDomainNotification(ValidationResult results)
        {
            foreach (var item in results.Errors)
            {
                _notification.Add(new NotificationDomainMessage(item.ErrorMessage));
            }
        }
    }
}
