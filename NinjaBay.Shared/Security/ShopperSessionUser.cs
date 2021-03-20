using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using NinjaBay.Shared.Constants;
using NinjaBay.Shared.ValueObjects;

namespace NinjaBay.Shared.Security
{
    public class ShopperSessionUser : SessionUser
    {
        public Address AddressInformation { get; set; }

        public Guid? AddressId { get; set; }
        public Identification Identification { get; set; }

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
            claims.Add(new Claim(CustomClaims.Address, AddressInformation?.Complement ?? ""));
            claims.Add(new Claim(CustomClaims.Identification, Identification?.Formatted ?? ""));
            claims.Add(new Claim(CustomClaims.AddressId,
                AddressId != Guid.Empty || AddressId != null ? AddressId.ToString() : ""));
            return new ClaimsPrincipal(new[] {new ClaimsIdentity(claims)});
        }
    }
}