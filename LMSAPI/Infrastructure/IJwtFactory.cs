
//https://github.com/mmacneil/AngularASPNETCore2WebApiAuth/blob/master/src/Auth/IJwtFactory.cs

using System.Security.Claims;
using System.Threading.Tasks;

namespace LMSAPI
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        string GenerateRefreshToken();
    }
}
