using System.Collections.Generic;
using System.Threading.Tasks;

namespace NinjaBay.Shared.Persistence
{
    public interface IStore<T> where T : class
    {
        Task AddOneAsync(T entity);
        Task AddMayAsync(IEnumerable<T> entities);
        Task ModifyAsync(T entity);
        Task RemoveOneAsync(T entity);
    }
}