using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Commands.User;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Services;
using SenacSp.ProjetoIntegrador.Domain.Entities;

namespace SenacSp.ProjetoIntegrador.Domain.CommandHandlers
{
    public class UserCommandHandler : BaseCommandHandler,
        IRequestHandler<CreateUserCommand, DefaultResult>,
        IRequestHandler<UpdateUserCommand, DefaultResult>,
        IRequestHandler<ChangeUserStatusCommand, DefaultResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwordHasherService;
        public UserCommandHandler(IUnitOfWork uow, IDomainNotification notifications,
            IUserRepository userRepository, IPasswordHasherService passwordHasherService) : base(uow, notifications)
        {
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<DefaultResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var user = User.New(command.Email,_passwordHasherService.Hash(command.Password),command.Name,command.UserType );

            await _userRepository.AddAsync(user);
            
            if (!await CommitAsync())
            {
                return result;
            }
            return result;
        }

        public async Task<DefaultResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var user = await _userRepository.FindAsync(x => x.Id == command.Id && x.Active == true);

            if (user == null)
            {
                Notifications.Handle("Id de usuário não encontrado");
                return null;
            }
            user.Update(command.Email,command.Name,command.UserType);
            
            _userRepository.Modify(user);
            
            if (!await CommitAsync())
            {
                return result;
            }
            return result;
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
            
            if (!await CommitAsync())
            {
                return result;
            }
            return result;
        }
    }
}
