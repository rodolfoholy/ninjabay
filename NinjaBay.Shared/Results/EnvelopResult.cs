using System.Collections.Generic;
using NinjaBay.Shared.Notifications;

namespace NinjaBay.Shared.Results
{
    public class EnvelopResult
    {
        public bool Success { get; private set; } = true;
        public IEnumerable<Notification> Errors { get; private set; } = new List<Notification>();

        public static EnvelopResult Ok()
        {
            return new EnvelopResult();
        }

        public static EnvelopResult Fail()
        {
            return new EnvelopResult {Success = false};
        }

        public static EnvelopResult Fail(IEnumerable<Notification> notifications)
        {
            return new EnvelopResult
            {
                Errors = notifications,
                Success = false
            };
        }
    }
}