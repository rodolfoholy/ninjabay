using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Projections;
using NinjaBay.Domain.Queries.User;
using NinjaBay.Domain.ViewModels;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Paging;

namespace NinjaBay.Domain.QueryHandler
{
    public class UserQueryHandler : BaseQueryHandler,
        IRequestHandler<PagedListUserQuery, PagedList<UserVm>>,
        IRequestHandler<UserByIdQuery, UserVm>
    {
        private readonly IUserRepository _userRepository;

        public UserQueryHandler(IDomainNotification notifications, IUserRepository userRepository) : base(notifications)
        {
            _userRepository = userRepository;
        }

        public async Task<PagedList<UserVm>> Handle(PagedListUserQuery query, CancellationToken cancellationToken)
        {
            var where = _userRepository.Where(query.Filter);

            var count = await _userRepository.CountAsync(where);

            var users = _userRepository.ListAsNoTracking(where, query.Filter).ToVm();

            return new PagedList<UserVm>(users, count, query.Filter.PageSize);
        }

        public async Task<UserVm> Handle(UserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.Id == query.Id);
            if (user != null) return user.ToVm();
            Notifications.Handle("Usuario Não encontrado");
            return null;
        }
    }
}