using UzTexGroupV2.Application.EntitiesDto.AuthenticationDtos;

namespace UzTexGroupV2.Application.Services;

public interface IAuthenticationService
{
    ValueTask<TokenDto> LoginAsync(LoginDto loginDto);

    ValueTask<TokenDto> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
}
