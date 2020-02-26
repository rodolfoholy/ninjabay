using SenacSp.ProjetoIntegrador.Shared.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace SenacSp.ProjetoIntegrador.Shared.Results
{
    public class EnvelopResult
    {
        public bool Success { get; private set; } = true;
        public IEnumerable<Notification> Errors { get; private set; } = new List<Notification>();

        public static EnvelopResult Ok() => new EnvelopResult();

        public static EnvelopResult Fail() => new EnvelopResult { Success = false };

        public static EnvelopResult Fail(IEnumerable<Notification> notifications) => new EnvelopResult
        {
            Errors = notifications,
            Success = false
        };
    }
}