using NinjaBay.Shared.Notifications;

namespace NinjaBay.Domain.QueryHandler
{
    public class BaseQueryHandler
    {
        protected IDomainNotification Notifications;

        public BaseQueryHandler(IDomainNotification notifications)
        {
            Notifications = notifications;
        }
    }
}