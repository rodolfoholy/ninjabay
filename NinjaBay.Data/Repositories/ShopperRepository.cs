using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;

namespace NinjaBay.Data.Repositories
{
    public class ShopperRepository : Repository<Shopper>, IShopperRepository
    {
        public ShopperRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}