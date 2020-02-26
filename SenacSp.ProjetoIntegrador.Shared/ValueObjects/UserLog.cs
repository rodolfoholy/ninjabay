using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Shared.ValueObjects
{
    public class UserLog
    {
        public UserLog()
        {
            OccurredAt = DateTime.UtcNow;
        }

        public UserLog(string id, string email, string name)
        {
            Id = id;
            Email = email;
            Name = name;
            OccurredAt = DateTime.UtcNow; ;
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public DateTime OccurredAt { get; set; }
    }
}
