using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Projections;
using SenacSp.ProjetoIntegrador.Domain.Queries.User;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Paging;

namespace SenacSp.ProjetoIntegrador.Domain.QueryHandler
{
    public class UserQueryHandler : BaseQueryHandler,
        IRequestHandler<PagedListUserQuery,PagedList<UserVm> >,
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