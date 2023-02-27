using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto;

public record CreateUserDto(
    [Required(ErrorMessage =$"{nameof(CreateUserDto.firstName)} berilishi majburiy ")]
    [MaxLength(30,ErrorMessage =$"Ismning uzunligi 15 tabelgidan kam bo'lishi kerak")]
    string firstName,

    [MaxLength(50,ErrorMessage =$"Familiyaning uzunligi 15 tabelgidan kam bo'lishi kerak")]
    string? lastName,

    [Required(ErrorMessage =$"{nameof(CreateUserDto.email)} berilishi majburiy ")]
    [EmailAddress(ErrorMessage =$"Email noto'g'ri kiritildi")]
    string email,

    [Required(ErrorMessage =$"parol berilishi majburiy ")]
    [MinLength(6,ErrorMessage ="uzunligi 6 tabelgidan kam bo'lmasligi kerak"),MaxLength(255)]
    string password);