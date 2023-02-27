using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UzTexGroupV2.Application.EntitiesDto.AuthenticationDtos;
using UzTexGroupV2.Infrastructure.Authentication;
using UzTexGroupV2.Infrastructure.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace UzTexGroupV2.Application.Services;

public partial class AuthenticationService : IAuthenticationService
{
    private readonly IGenerateToken generateToken;
    private readonly IPasswordHasher passwordHasher;
    private readonly JwtOptions jwtOptions;
    private readonly UnitOfWork unitOfWork;

    public AuthenticationService(
        IGenerateToken generateToken, 
        IPasswordHasher passwordHasher,
        IOptions<JwtOptions> jwtOptions,
        UnitOfWork unitOfWork)
    {
        this.generateToken = generateToken;
        this.passwordHasher = passwordHasher;
        this.jwtOptions = jwtOptions.Value;
        this.unitOfWork = unitOfWork;
    }

    public async ValueTask<TokenDto> LoginAsync(LoginDto loginDto)
    {
        var users = await this.unitOfWork.UserRepository.GetByExpression(
            expression: user => user.Email == loginDto.email,
            includes: new string[] { });

        var storageUser = users.FirstOrDefault();

        ValidateStorageUser(storageUser);

        ValidateStoragePassword(storageUser, loginDto);

        var createdRefreshToken = generateToken
            .GenerateRefreshToken();

        storageUser.RefreshToken = createdRefreshToken;

        storageUser.ExpiredRefreshToken = DateTime.Now.AddDays(5);

        var updateUser = await this.unitOfWork.UserRepository
            .UpdateAsync(storageUser);

        await this.unitOfWork.SaveChangesAsync();

        var createdAccessToken = generateToken
            .GenerateAccessToken(updateUser);

        return new TokenDto(
            accessToken: new JwtSecurityTokenHandler().WriteToken(createdAccessToken),
            refreshToken: createdRefreshToken,
            expireDate: createdAccessToken.ValidTo);
    }
        
    public async ValueTask<TokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
    {
        var claimsPrincipls = GetPrincipalFromExpiredToken(refreshTokenDto.accessToken);

        string userId = claimsPrincipls.FindFirst(ClaimNames.Id).Value;

        var users = await this.unitOfWork.UserRepository
            .GetByExpression(expression:
            user => user.Id == Guid.Parse(userId),
            includes: new string[] { });

        var storageUser = await users.FirstOrDefaultAsync();

        ValidateUser(storageUser);

        ValidateRefreshToken(
            refreshTokenDto: refreshTokenDto,
            user: storageUser);

        ValidateRefreshTokenExpiredDate(
            user: storageUser);

        var accessToken = this.generateToken.
            GenerateAccessToken(storageUser);

        return new TokenDto(
            accessToken: new JwtSecurityTokenHandler().WriteToken(accessToken),
            refreshToken: storageUser.RefreshToken,
            expireDate: accessToken.ValidTo);
        
    }
    private ClaimsPrincipal GetPrincipalFromExpiredToken(
        string accessToken)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidAudience = this.jwtOptions.Audience,
            ValidateIssuer = true,
            ValidIssuer = this.jwtOptions.Issuer,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(this.jwtOptions.SecretKey))
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var principal = tokenHandler.ValidateToken(
            token: accessToken,
            validationParameters: tokenValidationParameters,
            validatedToken: out SecurityToken securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;

        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(
            SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new ValidationException("Invalid token");
        }

        return principal;
    }
}
