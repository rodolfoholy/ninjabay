using SenacSp.ProjetoIntegrador.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Domain.Entities
{
    public class User
    {
        public User()
        {
        }

        public Guid Id { get; private set; }

        public string Email { get; private set; }

        public string Senha { get; private set; }
        public string Nome { get; private set; }    
        public bool Active { get; private set; }

        public EUserType Type { get; private set; }

        public void ChangeStatus() => Active = !Active;

        public static User New(string email, string senha, string name, EUserType type)
            => new User
            {
                Id = Guid.NewGuid(),
                Email = email,
                Senha = senha,
                Nome = name, Active = true,
                Type = type
            };

        public void Update(string email, string name, EUserType type)
        {
            Email = email;
            Nome = name;
            Type = type;
        }

        public void Update(string name, string senha)
        {
            Nome = name;
            Senha = senha;
        }
        
    }
}