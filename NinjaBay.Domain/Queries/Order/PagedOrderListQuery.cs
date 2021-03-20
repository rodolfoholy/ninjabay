using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.Filters;
using NinjaBay.Domain.ViewModels;
using NinjaBay.Shared.Paging;
using NinjaBay.Shared.Security;

namespace NinjaBay.Domain.Queries.Order
{
    public class PagedOrderListQuery : IRequest<PagedList<OrderVm>>
    {
        public OrderFilter Filter { get; set; }

        [JsonIgnore] public SessionUser SessionUser { get; set; }
    }
}