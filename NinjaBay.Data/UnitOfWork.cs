using System;
using System.Threading.Tasks;
using NinjaBay.Shared.Persistence;

namespace NinjaBay.Data
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
            catch (Exception e)
            {
                throw new Exception(e.InnerException?.Message ?? e.Message);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException?.Message ?? e.Message);
            }
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
            catch (Exception e)
            {
                RollbackTransaction();
                throw new Exception(e.InnerException?.Message ?? e.Message);
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _context.Database.CurrentTransaction.Rollback();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException?.Message ?? e.Message);
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                if (_context != null)
                    _context.Dispose();
        }
    }
}