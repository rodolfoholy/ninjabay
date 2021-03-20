using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;

namespace NinjaBay.Data.Repositories
{
    public class KeyWordRepository : Repository<KeyWord>, IKeyWordRepository
    {
        public KeyWordRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}