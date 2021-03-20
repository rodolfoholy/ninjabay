using Newtonsoft.Json;
using NinjaBay.Shared.Security;

namespace NinjaBay.Domain.Commands
{
    public class BaseCommandWithSessionUser
    {
        [JsonIgnore] public SessionUser SessionUser { get; set; }
    }
}