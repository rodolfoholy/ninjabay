using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;

namespace NinjaBay.Data.Repositories
{
    public class ShopperAddressRepository : Repository<ShopperAddress>, IShopperAddressRepository
    {
        public ShopperAddressRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}