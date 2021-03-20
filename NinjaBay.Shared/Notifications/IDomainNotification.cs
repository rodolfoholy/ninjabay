using System.Collections.Generic;

namespace NinjaBay.Shared.Notifications
{
    public interface IDomainNotification
    {
        List<Notification> Notifications { get; }
        void Handle(string value);
        void Handle(string key, string value);
        void Handle(Notification item);
        IEnumerable<Notification> Notify();
        bool HasNotifications();
        void Dispose();
    }
}