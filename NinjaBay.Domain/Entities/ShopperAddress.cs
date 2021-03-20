using System;
using System.Collections.Generic;
using NinjaBay.Shared.Enums;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Domain.Entities
{
    public class ShopperAddress
    {
        public Guid Id { get; private set; }

        public Shopper Shopper { get; private set; }

        public Guid ShopperId { get; private set; }

        public string Name { get; private set; }

        public EAddressType Type { get; private set; }
        public Address Address { get; private set; }

        public ICollection<Order> Orders { get; private set; }


        public static ShopperAddress New(Guid shopperId, EAddressType type, Address address, string name)
        {
            return new ShopperAddress
            {
                Id = Guid.NewGuid(),
                ShopperId = shopperId,
                Name = name,
                Address = address,
                Type = type
            };
        }

        public static ShopperAddress New(EAddressType type, Address address, string name)
        {
            return new ShopperAddress
            {
                Id = Guid.NewGuid(),
                Name = name,
                Address = address,
                Type = type
            };
        }

        public void Update(EAddressType? type = null, Address address = null, string name = null)
        {
            Name = name ?? Name;
            Address = address ?? Address;
            Type = type ?? Type;
        }
    }
}