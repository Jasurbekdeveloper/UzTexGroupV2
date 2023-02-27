using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto;

public record ModifyApplicationDto(

    [Required(ErrorMessage =$"{ nameof(ModifyApplicationDto.id)}  berilishi majburiy")]
    Guid id,

    [StringLength(15,ErrorMessage ="Ism 15 ta belgida oshmasligi kerak")]
    string? firstName,

    [StringLength(15,ErrorMessage ="Familiya 15 ta belgida oshmasligi kerak")]
    string? lastName,

    [RegularExpression( @"^\+?\d{1,3}[\s-]?\d{2,}[\s-]?\d{3,}[\s-]?\d{2,}[\s-]?\d{2,}$",
    ErrorMessage = "noto'g'ri raqam kirittingiz")]
    string? phoneNumber,

    string? applicationMassage,
    Guid? jobId,
    ModifyAddressDto? modifyAddressDto);
