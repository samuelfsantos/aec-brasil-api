using System;

namespace Aec.Brasil.Domain.Common.Notification
{
    public class NotificationDomainMessage 
    {
        public DateTimeOffset Timestamp { get; private set; }
        public Guid AggregateId { get; private set; }
        public string Message { get; private set; }

        public NotificationDomainMessage(string message)
        {
            Timestamp = DateTimeOffset.Now;
            this.Message = message;
        }

        public NotificationDomainMessage(string message, Guid aggregateId)
        {
            Timestamp = DateTimeOffset.Now;
            this.Message = message;
            this.AggregateId = aggregateId;
        }
    }
}
