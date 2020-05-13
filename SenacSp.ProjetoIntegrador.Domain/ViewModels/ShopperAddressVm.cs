using System;
using SenacSp.ProjetoIntegrador.Shared.Enums;
using SenacSp.ProjetoIntegrador.Shared.ValueObjects;

namespace SenacSp.ProjetoIntegrador.Domain.ViewModels
{
    public class ShopperAddressVm
    {
        public Guid Id { get;  set; }
        
        public string Name { get; set; }

        public EAddressType Type { get; set; }
        
        public Address Address { get; set; }
    }
}