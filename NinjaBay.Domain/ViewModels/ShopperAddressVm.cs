using System;
using NinjaBay.Shared.Enums;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Domain.ViewModels
{
    public class ShopperAddressVm
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public EAddressType Type { get; set; }

        public Address Address { get; set; }
    }
}