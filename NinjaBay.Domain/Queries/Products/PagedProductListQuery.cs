using MediatR;
using NinjaBay.Domain.Filters;
using NinjaBay.Domain.ViewModels;
using NinjaBay.Shared.Paging;

namespace NinjaBay.Domain.Queries
{
    public class PagedProductListQuery : IRequest<PagedList<ProductVm>>
    {
        public ProductFilter Filter { get; set; }
    }
}