using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace WayfJwtConnector.Extensions
{
    public static class ClaimsPrincipalExtension
    {
        public static string FindFirstOrEmpty(this ClaimsPrincipal principal, string type)
        {
            if (principal.HasClaim(c => c.Type == type))
            {
                return principal.FindFirst(type).Value;
            }
            return string.Empty;
        }

        public static string FindFirstOrEmpty(this ClaimsPrincipal principal, Predicate<Claim> match)
        {
            if (principal.HasClaim(match))
            {
                var claim = principal.FindFirst(match);
                return claim.Value;
            }
            return string.Empty;
        }
    }
}
