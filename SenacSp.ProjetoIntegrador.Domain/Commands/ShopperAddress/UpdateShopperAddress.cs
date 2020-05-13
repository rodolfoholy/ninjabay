using System;

namespace SenacSp.ProjetoIntegrador.Domain.Commands.ShopperAddress
{
    public class UpdateShopperAddressCommand : CreateShopperAddressCommand
    {
        public Guid Id { get; set; }
    }
}