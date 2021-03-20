using System;

namespace NinjaBay.Domain.Commands.ShopperAddress
{
    public class UpdateShopperAddressCommand : CreateShopperAddressCommand
    {
        public Guid Id { get; set; }
    }
}