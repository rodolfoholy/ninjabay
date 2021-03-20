using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NinjaBay.Domain.Commands.User;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Contracts.Services;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Persistence;

namespace NinjaBay.Domain.CommandHandlers
{
    public class UserCommandHandler : BaseCommandHandler,
        IRequestHandler<CreateUserCommand, DefaultResult>,
        IRequestHandler<UpdateUserCommand, DefaultResult>,
        IRequestHandler<ChangeUserStatusCommand, DefaultResult>
    {
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IUserRepository _userRepository;

        public UserCommandHandler(IUnitOfWork uow, IDomainNotification notifications,
            IUserRepository userRepository, IPasswordHasherService passwordHasherService) : base(uow, notifications)
        {
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<DefaultResult> Handle(ChangeUserStatusCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var user = await _userRepository.FindAsync(x => x.Id == command.Id);

            if (user == null)
            {
                Notifications.Handle("Id de usuário não encontrado");
                return null;
            }

            user.ChangeStatus();

            _userRepository.Modify(user);

            if (!await CommitAsync()) return result;
            return result;
        }

        public async Task<DefaultResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var user = User.New(command.Email, _passwordHasherService.Hash(command.Password), command.Name,
                command.UserType);

            await _userRepository.AddAsync(user);

            if (!await CommitAsync()) return result;
            return result;
        }

        public async Task<DefaultResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var user = await _userRepository.FindAsync(x => x.Id == command.Id && x.Active);

            if (user == null)
            {
                Notifications.Handle("Id de usuário não encontrado");
                return null;
            }

            user.Update(command.Email, command.Name, command.UserType);

            _userRepository.Modify(user);

            if (!await CommitAsync()) return result;
            return result;
        }
    }
}