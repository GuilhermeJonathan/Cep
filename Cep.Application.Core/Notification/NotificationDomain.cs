using MediatR;
using System;

namespace Default.Application.Core.Notification
{
    public class NotificationDomain : INotification
    {
        public NotificationDomain(string message)
        {
            Timestamp = DateTimeOffset.Now;
            this.Message = message;
        }

        public NotificationDomain(string messageId, string message)
        {
            Timestamp = DateTimeOffset.Now;
            this.MessageId = messageId;
            this.Message = message;
        }

        public NotificationDomain(string messageId, string message, int aggregateId)
        {
            Timestamp = DateTimeOffset.Now;
            this.MessageId = messageId;
            this.Message = message;
            this.AggregateId = aggregateId;
        }

        public DateTimeOffset Timestamp { get; private set; }
        public string MessageId { get; private set; }
        public string Message { get; private set; }
        public int AggregateId { get; private set; }
    }
}
