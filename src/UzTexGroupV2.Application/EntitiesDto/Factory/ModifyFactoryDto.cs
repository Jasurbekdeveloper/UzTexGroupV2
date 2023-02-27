using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto.Factory;

public record ModifyFactoryDto(
    [Required(ErrorMessage =$"{ nameof(ModifyFactoryDto.id)}  berilishi majburiy")]
    Guid id,
    [StringLength(15,ErrorMessage ="Ism 15 ta belgida oshmasligi kerak")]
    string? name,
    Guid? companyId,
    ModifyAddressDto? modifyAddressDto);

