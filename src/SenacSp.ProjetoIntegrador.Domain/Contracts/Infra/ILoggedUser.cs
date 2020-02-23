using SenacSp.ProjetoIntegrador.Shared.Security;
using System.Collections.Generic;
using System.Security.Claims;

namespace SenacSp.ProjetoIntegrador.Domain.Contracts.Infra
{
    public interface ILoggedUser
    {
        SessionUser User { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaims();
    }
}
