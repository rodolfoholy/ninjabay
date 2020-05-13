using MediatR;
using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Domain.Filters;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Paging;
using SenacSp.ProjetoIntegrador.Shared.Security;

namespace SenacSp.ProjetoIntegrador.Domain.Queries.Order
{
    public class PagedOrderListQuery : IRequest<PagedList<OrderVm>>
    {
        public OrderFilter Filter { get; set; }
        
        [JsonIgnore] public SessionUser SessionUser { get;  set; }
    }
}