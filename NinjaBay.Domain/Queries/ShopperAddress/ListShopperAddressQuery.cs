using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.ViewModels;
using NinjaBay.Shared.Security;

namespace NinjaBay.Domain.Queries.ShopperAddress
{
    public class ListShopperAddressQuery : IRequest<IEnumerable<ShopperAddressVm>>
    {
        [JsonIgnore] public SessionUser SessionUser { get; set; }
    }
}