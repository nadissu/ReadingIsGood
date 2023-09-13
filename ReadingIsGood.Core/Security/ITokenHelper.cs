using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ReadingIsGood.Core.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);

    }
}
