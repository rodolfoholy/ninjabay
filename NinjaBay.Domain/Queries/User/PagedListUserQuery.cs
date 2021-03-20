using MediatR;
using NinjaBay.Domain.Filters;
using NinjaBay.Domain.ViewModels;
using NinjaBay.Shared.Paging;

namespace NinjaBay.Domain.Queries.User
{
    public class PagedListUserQuery : IRequest<PagedList<UserVm>>
    {
        public UserFilter Filter { get; set; }
    }
}