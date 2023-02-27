using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.AuthenticationDtos;

public record LoginDto(
    [Required(ErrorMessage =$"{ nameof(LoginDto.email)}  berilishi majburiy")]
    string email,

    [Required(ErrorMessage =$"{ nameof(CreateApplicationDto.firstName)}  berilishi majburiy")]
    string password);
