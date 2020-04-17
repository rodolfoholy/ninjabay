using System;
using SenacSp.ProjetoIntegrador.Shared.ValueObjects;

namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class Shopper : BaseUser
    {
        public Guid Id { get; private set; }

        public Identification Cpf { get; private set; }

        public Address Address { get; private set; }

        public static Shopper New(User user, Identification cpf, Address address) => new Shopper
        {
            User = user,
            Address = address,
            Cpf = cpf,
            Id = user.Id
        };

        public void Update( Address address, string name)
        {
            User.Update(name);
            Address = address;
        }
        
    }
}