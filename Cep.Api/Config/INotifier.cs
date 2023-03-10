using System.Collections.Generic;

namespace Cep.Api.Config
{
    public interface INotifier
    {
        List<Notification> GetNotifications();
        void Handle(Notification notification);
        bool HasNotification();
    }
}
