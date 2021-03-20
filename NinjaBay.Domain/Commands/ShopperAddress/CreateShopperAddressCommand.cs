using MediatR;
using Newtonsoft.Json;
using NinjaBay.Domain.Results;
using NinjaBay.Shared.Enums;
using NinjaBay.Shared.Security;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Domain.Commands.ShopperAddress
{
    public class CreateShopperAddressCommand : IRequest<DefaultResult>
    {
        public string Name { get; set; }

        public EAddressType Type { get; set; }

        public Address Address { get; set; }

        [JsonIgnore] public SessionUser SessionUser { get; set; }
    }
}