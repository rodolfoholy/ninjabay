using SenacSp.ProjetoIntegrador.Shared.Persistence;
using System.Threading.Tasks;

namespace SenacSp.ProjetoIntegrador.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ECommerceDataContext _context;

        public UnitOfWork(ECommerceDataContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            try
            {
                return _context.SaveChanges() > 0;
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.InnerException?.Message ?? e.Message);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.InnerException?.Message ?? e.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _context.Database.CurrentTransaction.Commit();
            }
            catch (System.Exception e)
            {
                RollbackTransaction();
                throw new System.Exception(e.InnerException?.Message ?? e.Message);
            }

        }

        public void RollbackTransaction()
        {
            try
            {
                _context.Database.CurrentTransaction.Rollback();
            }
            catch (System.Exception e)
            {
                throw new System.Exception(e.InnerException?.Message ?? e.Message);
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
        }
    }
}
