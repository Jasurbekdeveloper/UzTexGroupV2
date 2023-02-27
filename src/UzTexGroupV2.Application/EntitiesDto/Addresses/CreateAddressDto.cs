using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.Addresses;

public record CreateAddressDto(
    [Required(ErrorMessage =$"{nameof(CreateAddressDto.country)} Berilishi majburiy")]
    [StringLength(50,ErrorMessage =$"Davlat nomi uzunligi 50 ta belgidan oshmasligi kerak")]
    string country,

    [Required(ErrorMessage =$"{nameof(CreateAddressDto.region)} berilishi majburiy")]
    [StringLength(100,ErrorMessage =$"Viloyat nomi uzunligi 100 ta belgidan oshmasligi kerak")]
    string region,

    [Required(ErrorMessage =$"{nameof(CreateAddressDto.district)} berilishi majburiy")]
    [StringLength(100,ErrorMessage =$"Tuman nomi uzunligi 100 ta belgidan oshmasligi kerak")]
    string district,


    [Required(ErrorMessage =$"{nameof(CreateAddressDto.street)} berilishi majburiy")]
    [StringLength(100,ErrorMessage =$"Kocha nomi uzunligi 100 ta belgidan oshmasligi kerak")]
    string street,

    [Required(ErrorMessage =$"{nameof(CreateAddressDto.postalCode)} berilishi majburiy")]
    short postalCode);