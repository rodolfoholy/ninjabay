using System.Threading.Tasks;

namespace SenacSp.ProjetoIntegrador.Shared.Persistence
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