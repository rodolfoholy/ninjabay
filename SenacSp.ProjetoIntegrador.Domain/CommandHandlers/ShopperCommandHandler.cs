using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Commands.Shopper;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Services;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Enums;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Persistence;
using SenacSp.ProjetoIntegrador.Shared.Utils;

namespace SenacSp.ProjetoIntegrador.Domain.CommandHandlers
{
    public class ShopperCommandHandler : BaseCommandHandler,
        IRequestHandler<CreateShopperCommand, SaveShopperResult>,
        IRequestHandler<UpdateShopperCommand, SaveShopperResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IShopperRepository _shopperRepository;
        private readonly IPasswordHasherService _passwordHasherService;

        public ShopperCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IUserRepository userRepository,
            IPasswordHasherService passwordHasherService, IShopperRepository shopperRepository) : base(uow,
            notifications)
        {
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
            _shopperRepository = shopperRepository;
        }

        public async Task<SaveShopperResult> Handle(CreateShopperCommand command, CancellationToken cancellationToken)
        {
            var result = new SaveShopperResult();
            
            if (await _userRepository.AnyAsync(x => x.Email.ToLower() == command.Email.ToLower()))
            {
                Notifications.Handle("E-mail em uso");
            }

            if (await _shopperRepository.AnyAsync(x => x.Cpf.Number.Equals(command.Cpf.Number)))
            {
                Notifications.Handle("CPF em uso");
            }

            if (Notifications.HasNotifications())
            {
                return null;
            }

            var user = User.New(command.Email,_passwordHasherService.Hash(command.Password),command.Name,EUserType.Shopper);

            var shopper = Shopper.New(user, command.Cpf, command.Address);
            result.Id = shopper.Id;
            await _shopperRepository.AddAsync(shopper);

            if (!await CommitAsync())
            {
                return null;
            }
            
            return result;
        }

        public async Task<SaveShopperResult> Handle(UpdateShopperCommand command, CancellationToken cancellationToken)
        {
            var result = new SaveShopperResult();
                
            var include = new IncludeHelper<Shopper>().Include(x => x.User).Includes;
            var shopper = await _shopperRepository.FindAsync(x => x.Id == command.SessionUser.Id, include);

            if (shopper == null)
            {
                Notifications.Handle("Usuario não é um comprador");
                return null;
            }
            
            shopper.Update(command.Name);

            if (!string.IsNullOrEmpty(command.Password))
            {
                shopper.User.UpdatePass(_passwordHasherService.Hash(command.Password));
            }
            
            result.Id = shopper.Id;
            
            _shopperRepository.Modify(shopper);
            
            if (!await CommitAsync())
            {
                return null;
            }
            
            return result;
        }
    }
}