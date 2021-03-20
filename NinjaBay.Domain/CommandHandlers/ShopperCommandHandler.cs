using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NinjaBay.Domain.Commands.Shopper;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Contracts.Services;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Enums;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Persistence;
using NinjaBay.Shared.Utils;

namespace NinjaBay.Domain.CommandHandlers
{
    public class ShopperCommandHandler : BaseCommandHandler,
        IRequestHandler<CreateShopperCommand, SaveShopperResult>,
        IRequestHandler<UpdateShopperCommand, SaveShopperResult>
    {
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IShopperAddressRepository _shopperAddressRepository;
        private readonly IShopperRepository _shopperRepository;
        private readonly IUserRepository _userRepository;


        public ShopperCommandHandler(IUnitOfWork uow, IDomainNotification notifications, IUserRepository userRepository,
            IPasswordHasherService passwordHasherService, IShopperRepository shopperRepository,
            IShopperAddressRepository shopperAddressRepository) : base(uow,
            notifications)
        {
            _userRepository = userRepository;
            _passwordHasherService = passwordHasherService;
            _shopperRepository = shopperRepository;
            _shopperAddressRepository = shopperAddressRepository;
        }

        public async Task<SaveShopperResult> Handle(CreateShopperCommand command, CancellationToken cancellationToken)
        {
            var result = new SaveShopperResult();

            if (await _userRepository.AnyAsync(x => x.Email.ToLower() == command.Email.ToLower()))
                Notifications.Handle("E-mail em uso");

            if (await _shopperRepository.AnyAsync(x => x.Cpf.Number.Equals(command.Cpf.Number)))
                Notifications.Handle("CPF em uso");

            if (Notifications.HasNotifications()) return null;

            var user = User.New(command.Email, _passwordHasherService.Hash(command.Password), command.Name,
                EUserType.Shopper);
            command.Cpf.Type = EIdentiticationType.Cpf;
            var shopper = Shopper.New(user, command.Cpf);

            await _shopperRepository.AddAsync(shopper);

            if (!await CommitAsync()) return null;

            await _shopperAddressRepository.AddAsync(ShopperAddress.New(shopper.Id, EAddressType.Home, command.Address,
                "registro"));

            if (!await CommitAsync()) return null;

            result.Id = shopper.Id;
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
                shopper.User.UpdatePass(_passwordHasherService.Hash(command.Password));

            result.Id = shopper.Id;

            _shopperRepository.Modify(shopper);

            if (!await CommitAsync()) return null;

            return result;
        }
    }
}