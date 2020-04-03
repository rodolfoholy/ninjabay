using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Filters;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Paging;

namespace SenacSp.ProjetoIntegrador.Domain.Queries.User
{
    public class PagedListUserQuery : IRequest<PagedList<UserVm>>
    {
        public UserFilter Filter { get; set; }
    }
}