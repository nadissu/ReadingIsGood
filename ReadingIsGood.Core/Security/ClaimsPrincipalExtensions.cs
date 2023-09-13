using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Core.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static List<string>? Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            List<string>? result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }

        public static List<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }

        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var userIdClaim = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            int userId = userIdClaim != null ? Convert.ToInt32(userIdClaim.Value) : 0;
            return userId;
        }
    }
}
