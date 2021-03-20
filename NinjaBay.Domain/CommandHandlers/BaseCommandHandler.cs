using System.Threading.Tasks;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Persistence;

namespace NinjaBay.Domain.CommandHandlers
{
    public class BaseCommandHandler
    {
        protected readonly IUnitOfWork Uow;
        protected IDomainNotification Notifications;

        public BaseCommandHandler(IUnitOfWork uow, IDomainNotification notifications)
        {
            Uow = uow;
            Notifications = notifications;
        }

        public async Task<bool> CommitAsync()
        {
            if (Notifications.HasNotifications()) return false;

            if (await Uow.SaveChangesAsync()) return true;

            Notifications.Handle(new Notification("Ocorreu um erro ao salvar os dados"));

            return false;
        }
    }
}