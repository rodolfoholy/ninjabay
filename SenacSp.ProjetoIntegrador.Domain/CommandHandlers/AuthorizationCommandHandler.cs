using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Commands.Auth;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Services;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Enums;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Persistence;
using SenacSp.ProjetoIntegrador.Shared.Security;
using SenacSp.ProjetoIntegrador.Shared.Utils;

namespace SenacSp.ProjetoIntegrador.Domain.CommandHandlers
{
    public class AuthorizationCommandHandler : BaseCommandHandler,
        IRequestHandler<AuthCommand,AuthResult>
    {
        private readonly JwtTokenConfig _jwtTokenConfig;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IShopperRepository _shopperRepository;
        
        public AuthorizationCommandHandler(IUnitOfWork uow, IDomainNotification notifications, JwtTokenConfig jwtTokenConfig, IUserRepository userRepository, IPasswordHasherService passwordHasherService, IShopperRepository shopperRepository) : base(uow, notifications)
        {
            _jwtTokenConfig = jwtTokenConfig;
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
            _shopperRepository = shopperRepository;
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

        switch (user.Type)
        {
            case EUserType.Administrator:
                return await HandleAdmin(user);
            case EUserType.Shopper:
                return await HandleShopper(user);
            default:
                return null;
        }
        
        }

        private async Task<AuthResult> HandleAdmin(User user)
        {
            var authResult = new AuthResult();
            
            var sessionUser = new SessionUser
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Nome,
                UserType = user.Type.ToString()
            };
        
            authResult.UserInfo = sessionUser;
        
            authResult.Token = _jwtTokenConfig.GenerateJwtToken(sessionUser.ClaimsPrincipal());
            
            return authResult;
        }
        
        private async Task<AuthResult> HandleShopper(User user)
        {
            
            var authResult = new AuthResult();
            
            var shopperInclude = new IncludeHelper<Shopper>()
                .Include(x => x.User)
                .Include(x => x.Addresses)
                .Includes;
            var shopper = await _shopperRepository.FindAsync(x => x.Id == user.Id,shopperInclude);
           
            var sessionUser = new ShopperSessionUser()
            {
                Id = shopper.Id,
                Email = shopper.User.Email,
                Name = shopper.User.Nome,
                UserType = shopper.User.Type.ToString(),
                AddressInformation = shopper.Addresses.First().Address,
                Identification = shopper.Cpf,
                AddressId = shopper.Addresses.FirstOrDefault().Id
            };
        
            authResult.UserInfo = sessionUser;
        
            authResult.Token = _jwtTokenConfig.GenerateJwtToken(sessionUser.ClaimsPrincipal());
            return authResult;
        }
    }
}