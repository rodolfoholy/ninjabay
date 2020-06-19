using System;
using SenacSp.ProjetoIntegrador.Shared.Enums;
using SenacSp.ProjetoIntegrador.Shared.Extensions;

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

        public EUserType Type { get; set; }
        public string TypeDescription => Type.Description();
    }
}