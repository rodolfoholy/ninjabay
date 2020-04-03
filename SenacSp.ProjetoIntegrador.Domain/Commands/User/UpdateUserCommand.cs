using System;
using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Enums;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.User
{
    public class UpdateUserCommand : IRequest<DefaultResult>
    {
        public Guid Id { get; set; }
        
        public string Email { get; set; }
        
        public string Name { get; set; }

        public EUserType UserType { get; set; }
    }
}