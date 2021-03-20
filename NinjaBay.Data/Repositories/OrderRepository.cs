using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;

namespace NinjaBay.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ECommerceDataContext context) : base(context)
        {
        }
    }
}