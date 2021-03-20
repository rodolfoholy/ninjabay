using System;
using NinjaBay.Shared.Enums;
using NinjaBay.Shared.Extensions;

namespace NinjaBay.Domain.ViewModels
{
    public class UserVm
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Nome { get; set; }

        public bool Active { get; set; }

        public EUserType Type { get; set; }
        public string TypeDescription => Type.Description();
    }
}