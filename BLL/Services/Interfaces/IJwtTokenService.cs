using System.Security.Claims;

namespace BLL.Services.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}