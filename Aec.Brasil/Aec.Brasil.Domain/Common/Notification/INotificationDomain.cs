using System;
using System.Collections.Generic;

namespace Aec.Brasil.Domain.Common.Notification
{
    public interface INotificationDomain<NotificationDomainMessage>
    {
        void Add(NotificationDomainMessage notification);
        List<NotificationDomainMessage> GetAll();
        List<NotificationDomainMessage> GetAll(Guid aggregateId);
        bool HasNotifications();
        bool ContainsNotification(string text);
        bool HasNotifications(Guid aggregateId);
        void Dispose();
    }
}
