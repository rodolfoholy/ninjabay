using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Projections;
using NinjaBay.Domain.Queries;
using NinjaBay.Domain.ViewModels;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Paging;

namespace NinjaBay.Domain.QueryHandler
{
    public class ProductQueryHandler : BaseQueryHandler,
        IRequestHandler<PagedProductListQuery, PagedList<ProductVm>>,
        IRequestHandler<GetProductByIdQuery, ProductVm>


    {
        private readonly IProductRepository _productRepository;

        public ProductQueryHandler(IDomainNotification notifications, IProductRepository productRepository) : base(
            notifications)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductVm> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return _productRepository.FindAsNoTracking(x => x.Id == query.Id).ToVm();
        }

        public async Task<PagedList<ProductVm>> Handle(PagedProductListQuery query, CancellationToken cancellationToken)
        {
            var where = _productRepository.Where(query.Filter);
            var count = await _productRepository.CountAsync(where);

            var products = _productRepository.ListAsNoTracking(where, query.Filter).ToVm();

            return new PagedList<ProductVm>(products, count, query.Filter.PageSize);
        }
    }
}