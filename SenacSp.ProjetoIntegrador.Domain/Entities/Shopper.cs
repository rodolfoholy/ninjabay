using System;
using System.Collections.Generic;
using SenacSp.ProjetoIntegrador.Shared.ValueObjects;

namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class Shopper : BaseUser
    {
        public Guid Id { get; private set; }

        public Identification Cpf { get; private set; }

        public ICollection<ShopperAddress> Addresses { get; private set; } = new List<ShopperAddress>();
        

        public static Shopper New(User user, Identification cpf) => new Shopper
        {
            User = user,
            Cpf = cpf,
            Id = user.Id
        };

        public ICollection<Order> Orders { get; private set; }= new List<Order>();

        public ICollection<ShopperAddress> ShopperAddresses { get; private set; } = new List<ShopperAddress>();

        public void Update( string name)
        {
            User.Update(name);
        }
        
    }
}