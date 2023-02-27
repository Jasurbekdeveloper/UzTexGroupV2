using UzTexGroupV2.Application.EntitiesDto.AuthenticationDtos;
using UzTexGroupV2.Domain;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Domain.Exceptions;

namespace UzTexGroupV2.Application.Services;

public partial class AuthenticationService
{
    private void ValidateStorageUser(User user)
    {
        if (user == null)
            throw new NotFoundException("Email yoki password xato");
    }
    private void ValidateStoragePassword(User user, LoginDto loginDto)
    {
        if(!passwordHasher.VerifyPassword(
            password: loginDto.password,
            salt: user.Salt,
            hash: user.PasswordHash))
        {
            throw new NotFoundException("Email yoki password xato");
        }
    }
    private void ValidateRefreshToken(
        RefreshTokenDto refreshTokenDto, User user)
    {
        if (!user.RefreshToken.Equals(refreshTokenDto.refreshToken))
            throw new InvalidRefreshTokenException("Refresh token yaroqsiz");
    }
    private void ValidateRefreshTokenExpiredDate(User user)
    {
        if (user.ExpiredRefreshToken <= DateTime.Now)
            throw new InvalidRefreshTokenException("Refresh token muddati o'tib ketgan");
    }
    private void ValidateUser(User user)
    {
        if(user is null)
        {
            throw new NotFoundException("Bu token yaroqsiz.");
        }
    }
}
