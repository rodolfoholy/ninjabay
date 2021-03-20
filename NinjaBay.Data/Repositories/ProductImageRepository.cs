using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;

namespace NinjaBay.Data.Repositories
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}