using System.Threading.Tasks;

namespace NinjaBay.Shared.Persistence
{
    public interface IUnitOfWork
    {
        bool SaveChanges();

        Task<bool> SaveChangesAsync();

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}