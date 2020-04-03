using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Commands.Auth;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Services;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Persistence;
using SenacSp.ProjetoIntegrador.Shared.Security;

namespace SenacSp.ProjetoIntegrador.Domain.CommandHandlers
{
    public class AuthorizationCommandHandler : BaseCommandHandler,
        IRequestHandler<AuthCommand,AuthResult>
    {
        private readonly JwtTokenConfig _jwtTokenConfig;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwordHasherService;
        
        public AuthorizationCommandHandler(IUnitOfWork uow, IDomainNotification notifications, JwtTokenConfig jwtTokenConfig, IUserRepository userRepository, IPasswordHasherService passwordHasherService) : base(uow, notifications)
        {
            _jwtTokenConfig = jwtTokenConfig;
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
        }

        public async Task<AuthResult> Handle(AuthCommand command, CancellationToken cancellationToken)
        {
        var result = new AuthResult();
        
        var user = await _userRepository.FindAsync(x => x.Email.ToLower().Equals(command.Email.ToLower()) && x.Active == true);
        
        if (user == null)
        {
            Notifications.Notifications.Add(new Notification("Credencial invalida."));
            return result;
        }
        if (!_passwordHasherService.Check(user.Senha, command.Senha))
        {
            Notifications.Notifications.Add(new Notification("Senha invalida"));
            return result;
        }

        var sessionUser = new SessionUser
        {
        Id = user.Id,
        Email = user.Email,
        Name = user.Nome,
        UserType = user.Type.ToString()
        };
        
        result.UserInfo = sessionUser;
        
        result.Token = _jwtTokenConfig.GenerateJwtToken(sessionUser.ClaimsPrincipal());

        // codigo que será usado no futuro quando houver especificação de tipos de usuario
        // switch (user.Type)
        // {
        //     case EUserType.Administrator:
        //         
        //         break;
        //     default:
        //         return null;
        // }
        
        return result;
        }
        //
        // private async Task<AuthResult> HandleAdmin(User user)
        // {
        //     
        // };
    }
}