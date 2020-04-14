using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;

namespace SenacSp.ProjetoIntegrador.Data.Repositories
{
    public class ShopperRepository: Repository<Shopper>, IShopperRepository 
    {
        public ShopperRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}