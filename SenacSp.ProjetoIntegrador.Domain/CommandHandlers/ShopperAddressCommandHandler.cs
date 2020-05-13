using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Commands.Shopper;
using SenacSp.ProjetoIntegrador.Domain.Commands.ShopperAddress;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Entities;
using SenacSp.ProjetoIntegrador.Domain.Results;
using SenacSp.ProjetoIntegrador.Shared.Notifications;
using SenacSp.ProjetoIntegrador.Shared.Persistence;

namespace SenacSp.ProjetoIntegrador.Domain.CommandHandlers
{
    public class ShopperAddressCommandHandler : BaseCommandHandler,
        IRequestHandler<CreateShopperAddressCommand,DefaultResult>,
        IRequestHandler<UpdateShopperAddressCommand,DefaultResult>
    {
        private readonly IShopperAddressRepository _shopperAddressRepository;

        public ShopperAddressCommandHandler(IUnitOfWork uow,IShopperAddressRepository shopperAddressRepository  , IDomainNotification notifications) : base(uow, notifications)
        {
            _shopperAddressRepository = shopperAddressRepository;
        }

        public async Task<DefaultResult> Handle(CreateShopperAddressCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            await _shopperAddressRepository.AddAsync(ShopperAddress.New(command.SessionUser.Id, command.Type, command.Address, command.Name));
            
            if (!await CommitAsync())
            {
                return null;
            }
            
            return result;
        }

        public async Task<DefaultResult> Handle(UpdateShopperAddressCommand command, CancellationToken cancellationToken)
        {
            var result = new DefaultResult();

            var address = await _shopperAddressRepository.FindAsync(x => x.Id == command.Id && x.ShopperId == command.SessionUser.Id);

            if (address == null)
            {
                Notifications.Handle("Endereço não encontrado");
                return null;  
            }

            address.Update(command.Type,command.Address,command.Name);
            
            _shopperAddressRepository.Modify(address);
            
            if (!await CommitAsync())
            {
                return null;
            }
            
            return result;
        }
    }
}