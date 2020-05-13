using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;

namespace SenacSp.ProjetoIntegrador.Data.Repositories
{
    public class ShopperAddressRepository : Repository<ShopperAddress>, IShopperAddressRepository
    {
        public ShopperAddressRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}