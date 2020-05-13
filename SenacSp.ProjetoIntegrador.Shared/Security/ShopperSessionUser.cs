using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using SenacSp.ProjetoIntegrador.Shared.Constants;
using SenacSp.ProjetoIntegrador.Shared.ValueObjects;

namespace SenacSp.ProjetoIntegrador.Shared.Security
{
    public class ShopperSessionUser : SessionUser
    {
        public Address Address { get; set; }
        
        public static ShopperSessionUser UserShopper(IEnumerable<Claim> claims)
        {
            var claimsArray = claims as Claim[] ?? claims.ToArray();
            if (!(User(claimsArray) is ShopperSessionUser user))
                return null;
            // user.Address = claimsArray.First(x => x.Type == CustomClaims.Address).Value;
            return user;
        }
        
        public override ClaimsPrincipal ClaimsPrincipal()
        {
            var claims = Claims();
            // claims.Add(new Claim(CustomClaims.Address,Address ?? ""));
            return new ClaimsPrincipal(new[] { new ClaimsIdentity(claims) });
        }
    }
}