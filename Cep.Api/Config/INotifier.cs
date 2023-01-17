using System.Collections.Generic;

namespace Default.Api.Config
{
    public interface INotifier
    {
        List<Notification> GetNotifications();
        void Handle(Notification notification);
        bool HasNotification();
    }
}
