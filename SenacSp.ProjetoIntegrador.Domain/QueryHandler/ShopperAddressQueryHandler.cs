using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SenacSp.ProjetoIntegrador.Domain.Contracts.Repositories;
using SenacSp.ProjetoIntegrador.Domain.Projections;
using SenacSp.ProjetoIntegrador.Domain.Queries.ShopperAddress;
using SenacSp.ProjetoIntegrador.Domain.ViewModels;
using SenacSp.ProjetoIntegrador.Shared.Notifications;

namespace SenacSp.ProjetoIntegrador.Domain.QueryHandler
{
    public class ShopperAddressQueryHandler : BaseQueryHandler,
        IRequestHandler<ListShopperAddressQuery,IEnumerable<ShopperAddressVm>>
    {
        private readonly IShopperAddressRepository _shopperAddressRepository;

        public ShopperAddressQueryHandler(IDomainNotification notifications, IShopperAddressRepository shopperAddressRepository  ) : base(notifications)
        {
            _shopperAddressRepository = shopperAddressRepository;
        }

        public async Task<IEnumerable<ShopperAddressVm>> Handle(ListShopperAddressQuery query, CancellationToken cancellationToken)
        {
            return( _shopperAddressRepository.ListAsNoTracking(x => x.ShopperId == query.SessionUser.Id)).OrderBy(x => x.Name).ToVm();
        }
    }
}