using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto;

public record ModifyUserDto(
    [Required(ErrorMessage =$"{nameof(ModifyUserDto.id)} berilishi kerak")]
    Guid id,

    [MaxLength(30 ,ErrorMessage ="15 ta belgidan oshmasligi kerak")]
    string? firstName,

    [MaxLength(50 ,ErrorMessage ="15 ta belgidan oshmasligi kerak")]
    string? lastName,

    [EmailAddress(ErrorMessage =$"Email noto'g'ri kiritildi")]
    string? email);
