using Newtonsoft.Json;
using SenacSp.ProjetoIntegrador.Shared.Security;

namespace SenacSp.ProjetoIntegrador.Domain.Commands
{
    public class BaseCommandWithSessionUser
    {
        [JsonIgnore]
        public SessionUser SessionUser { get; set; }
    }
}