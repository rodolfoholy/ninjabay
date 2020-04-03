using System;
using SenacSp.ProjetoIntegrador.Shared.Enums;

namespace SenacSp.ProjetoIntegrador.Domain.ViewModels
{
    public class UserVm
    {
        public UserVm()
        {
            
        }
        public Guid Id { get;  set; }

        public string Email { get;  set; }

        public string Nome { get;  set; }

        public bool Active { get;  set; }

        public EUserType Type { get;  set; }
    }
}