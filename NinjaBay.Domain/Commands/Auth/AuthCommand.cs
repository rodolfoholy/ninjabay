using MediatR;
using NinjaBay.Domain.Results;

namespace NinjaBay.Domain.Commands.Auth
{
    public class AuthCommand : IRequest<AuthResult>
    {
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}