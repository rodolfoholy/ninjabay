using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Projections;
using SenacSp.ProjetoIntegrador.Domain.Queries.Order;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Paging;
using SenacSp.ProjetoIntegrador.Shared.Utils;

namespace SenacSp.ProjetoIntegrador.Domain.QueryHandler
{
    public class OrderQueryHandler : BaseQueryHandler,
        IRequestHandler<PagedOrderListQuery, PagedList<OrderVm>>,
        IRequestHandler<GetOrderByIdQuery, OrderVm>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderQueryHandler(IDomainNotification notifications, IOrderRepository orderRepository) : base(
            notifications)
        {
            _orderRepository = orderRepository;
        }

        public async Task<PagedList<OrderVm>> Handle(PagedOrderListQuery query, CancellationToken cancellationToken)
        {
            var where = PredicateBuilder.True<Order>();

            var count = await _orderRepository.CountAsync(where);
          
            var includes = new IncludeHelper<Order>()
                .Include(x => x.ShippingAddress)
                .Include(x => x.Products)
                .Include(x => x.Products.Select(x => x.Product).Count() > 0)
                .Include(x => (x.Products.Select(x => x.Product).Select(y => y.Images).Count() > 0))
                .Includes;
            
            var orders = _orderRepository.ListAsNoTracking(where, query.Filter, includes: includes).ToVm();

            return new PagedList<OrderVm>(orders, count, query.Filter.PageSize);
        }

        public async Task<OrderVm> Handle(GetOrderByIdQuery query, CancellationToken cancellationToken)
        {
            var includes = new IncludeHelper<Order>()
                .Include(x => x.ShippingAddress)
                .Include(x => x.Products)
                .Include(x => x.Products.Select(x => x.Product).Count() > 0)
                .Include(x => (x.Products.Select(x => x.Product).Select(y => y.Images).Count() > 0))
                .Includes;
            return (await _orderRepository.FindAsync(x =>
                x.Id == query.Id && x.ShopperId == query.SessionUser.Id, includes)).ToVm();
        }
    }
}