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

namespace SenacSp.ProjetoIntegrador.Domain.CommandHandlers
{
    public class UserCommandHandler : BaseCommandHandler, IRequestHandler<CreateUserCommand, DefaultResult>
    {
        public UserCommandHandler(IUnitOfWork uow, IDomainNotification notifications) : base(uow, notifications)
        {
        }

        public Task<DefaultResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
