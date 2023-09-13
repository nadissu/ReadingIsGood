using Microsoft.IdentityModel.Tokens;

namespace ReadingIsGood.Core.Security
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        }
    }
}
