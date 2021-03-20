using System;
using System.Collections.Generic;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Domain.Entities
{
    public class Shopper : BaseUser
    {
        public Guid Id { get; private set; }

        public Identification Cpf { get; private set; }

        public ICollection<ShopperAddress> Addresses { get; } = new List<ShopperAddress>();

        public ICollection<Order> Orders { get; } = new List<Order>();

        public ICollection<ShopperAddress> ShopperAddresses { get; } = new List<ShopperAddress>();


        public static Shopper New(User user, Identification cpf)
        {
            return new Shopper
            {
                User = user,
                Cpf = cpf,
                Id = user.Id
            };
        }

        public void Update(string name)
        {
            User.Update(name);
        }
    }
}