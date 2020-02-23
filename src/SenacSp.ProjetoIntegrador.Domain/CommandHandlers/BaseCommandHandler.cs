using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Persistence;
using System.Threading.Tasks;

namespace SenacSp.ProjetoIntegrador.Domain.CommandHandlers
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