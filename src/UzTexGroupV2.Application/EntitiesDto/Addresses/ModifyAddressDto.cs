using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.Addresses;
public record ModifyAddressDto(
    [Required(ErrorMessage =$"{nameof(ModifyAddressDto.addressId)} berilishi majburiy")]
    Guid addressId,

    [StringLength(50,ErrorMessage =$"Davlat nomi uzunligi 50 ta belgidan oshmasligi kerak")]
    string? country,

    [StringLength(100,ErrorMessage =$"Viloyat nomi uzunligi 100 ta belgidan oshmasligi kerak")]
    string? region,

    [StringLength(100,ErrorMessage =$"Tuman nomi uzunligi 100 ta belgidan oshmasligi kerak")]
    string? district,

    [StringLength(100,ErrorMessage =$"Kocha nomi uzunligi 100 ta belgidan oshmasligi kerak")]
    string? street,

    short? postalCode);
