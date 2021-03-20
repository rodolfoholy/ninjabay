using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using NinjaBay.Domain.Contracts.Infra;
using NinjaBay.Shared.Security;

namespace NinjaBay.Infra
{
    public class LoggedUser : ILoggedUser
    {
        private readonly IHttpContextAccessor _accessor;


        public LoggedUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaims()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public SessionUser User
        {
            get
            {
                var claims = GetClaims().ToList();

                if (!claims.Any()) return null;

                try
                {
                    return SessionUser.User(claims);
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}