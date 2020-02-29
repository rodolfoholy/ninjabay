using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Projections;
using SenacSp.ProjetoIntegrador.Domain.Queries;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SenacSp.ProjetoIntegrador.Domain.QueryHandler
{
    public class ProductQueryHandler : BaseQueryHandler,
        IRequestHandler<PagedProductListQuery, PagedList<ProductVm>>,
        IRequestHandler<GetProductByIdQuery, ProductVm>

        
    {
        private readonly IProductRepository _productRepository;

        public ProductQueryHandler(IDomainNotification notifications, IProductRepository productRepository) : base(notifications)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedList<ProductVm>> Handle(PagedProductListQuery query, CancellationToken cancellationToken)
        {
            var where = _productRepository.Where(query.Filter);

            var count = await _productRepository.CountAsync(where);

            var products = _productRepository.ListAsNoTracking(where, query.Filter).ToVm();

            return new PagedList<ProductVm>(products, count, query.Filter.PageSize);
        }

        public async Task<ProductVm> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return _productRepository.FindAsNoTracking(x => x.Id == query.Id).ToVm();
        }
    }
}
