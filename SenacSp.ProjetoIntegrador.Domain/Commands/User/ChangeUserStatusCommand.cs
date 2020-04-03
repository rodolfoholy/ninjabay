using System;
using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Results;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.User
{
    public class ChangeUserStatusCommand : IRequest<DefaultResult>
    {
        public Guid Id { get; set; }
    }
}