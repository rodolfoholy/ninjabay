using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Results;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.Auth
{
    public class AuthCommand : IRequest<AuthResult>
    {
        public string Email { get; set; }
        
        public string Senha { get; set; }
    }
}