using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NinjaBay.Domain.Contracts.Repositories;
using NinjaBay.Domain.Projections;
using NinjaBay.Domain.Queries.ShopperAddress;
using NinjaBay.Domain.ViewModels;
using NinjaBay.Shared.Notifications;

namespace NinjaBay.Domain.QueryHandler
{
    public class ShopperAddressQueryHandler : BaseQueryHandler,
        IRequestHandler<ListShopperAddressQuery, IEnumerable<ShopperAddressVm>>
    {
        private readonly IShopperAddressRepository _shopperAddressRepository;

        public ShopperAddressQueryHandler(IDomainNotification notifications,
            IShopperAddressRepository shopperAddressRepository) : base(notifications)
        {
            _shopperAddressRepository = shopperAddressRepository;
        }

        public async Task<IEnumerable<ShopperAddressVm>> Handle(ListShopperAddressQuery query,
            CancellationToken cancellationToken)
        {
            return _shopperAddressRepository.ListAsNoTracking(x => x.ShopperId == query.SessionUser.Id)
                .OrderBy(x => x.Name).ToVm();
        }
    }
}