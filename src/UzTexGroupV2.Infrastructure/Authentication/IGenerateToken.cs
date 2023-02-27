using System.IdentityModel.Tokens.Jwt;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Infrastructure.Authentication;

public interface IGenerateToken
{
    JwtSecurityToken GenerateAccessToken(User user);

    string GenerateRefreshToken();
}
