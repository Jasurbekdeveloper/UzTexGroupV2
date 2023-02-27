using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.AuthenticationDtos;

public record RefreshTokenDto(
    [Required(ErrorMessage =$"{ nameof(RefreshTokenDto.accessToken)}  berilishi majburiy")]
    string accessToken,

    [Required(ErrorMessage =$"{ nameof(RefreshTokenDto.refreshToken)}  berilishi majburiy")]
    string refreshToken);
