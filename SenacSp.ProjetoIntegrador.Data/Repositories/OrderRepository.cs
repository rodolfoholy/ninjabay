using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;

namespace SenacSp.ProjetoIntegrador.Data.Repositories
{
    public class OrderRepository : Repository<Order> , IOrderRepository
    {
        public OrderRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}