using System.Collections.Generic;
using System.Security.Claims;
using NinjaBay.Shared.Security;

namespace NinjaBay.Domain.Contracts.Infra
{
    public interface ILoggedUser
    {
        SessionUser User { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaims();
    }
}