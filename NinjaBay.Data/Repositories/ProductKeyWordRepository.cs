using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;

namespace NinjaBay.Data.Repositories
{
    public class ProductKeyWordRepository : Repository<ProductKeyWord>, IProductKeyWordRepository
    {
        public ProductKeyWordRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}