using System;
using NinjaBay.Shared.Enums;

namespace NinjaBay.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Nome { get; private set; }
        public bool Active { get; private set; }

        public EUserType Type { get; private set; }

        public void ChangeStatus()
        {
            Active = !Active;
        }

        public static User New(string email, string senha, string name, EUserType type)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Email = email,
                Senha = senha,
                Nome = name, Active = true,
                Type = type
            };
        }

        public void Update(string email, string name, EUserType type)
        {
            Email = email;
            Nome = name;
            Type = type;
        }

        public void Update(string name)
        {
            Nome = string.IsNullOrEmpty(name) ? Nome : name;
        }

        public void UpdatePass(string senha)
        {
            Senha = string.IsNullOrEmpty(senha) ? Senha : senha;
        }
    }
}