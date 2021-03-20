using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NinjaBay.Domain.Commands.ShopperAddress;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Entities;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Notifications;
using NinjaBay.Shared.Persistence;

namespace NinjaBay.Domain.CommandHandlers
{
    public class ShopperAddressCommandHandler : BaseCommandHandler,
        IRequestHandler<CreateShopperAddressCommand, DefaultResult>,
        IRequestHandler<UpdateShopperAddressCommand, DefaultResult>
    {
        private readonly IShopperAddressRepository _shopperAddressRepository;

        public ShopperAddressCommandHandler(IUnitOfWork uow, IShopperAddressRepository shopperAddressRepository,
            IDomainNotification notifications) : base(uow, notifications)
        {
            _shopperAddressRepository = shopperAddressRepository;
        }

        public async Task<DefaultResult> Handle(CreateShopperAddressCommand command,
            CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            await _shopperAddressRepository.AddAsync(ShopperAddress.New(command.SessionUser.Id, command.Type,
                command.Address, command.Name));

            if (!await CommitAsync()) return null;

            return result;
        }

        public async Task<DefaultResult> Handle(UpdateShopperAddressCommand command,
            CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var address =
                await _shopperAddressRepository.FindAsync(x =>
                    x.Id == command.Id && x.ShopperId == command.SessionUser.Id);

            if (address == null)
            {
                Notifications.Handle("Endereço não encontrado");
                return null;
            }

            address.Update(command.Type, command.Address, command.Name);

            _shopperAddressRepository.Modify(address);

            if (!await CommitAsync()) return null;

            return result;
        }
    }
}