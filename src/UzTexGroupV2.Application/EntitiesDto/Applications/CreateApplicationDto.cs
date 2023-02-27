using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto;

public record CreateApplicationDto(
    [Required(ErrorMessage =$"{ nameof(CreateApplicationDto.firstName)}  berilishi majburiy")]
    [StringLength(15,ErrorMessage ="Ism 15 ta belgida oshmasligi kerak")]
    string firstName,

    [StringLength(15,ErrorMessage ="Familiya 15 ta belgida oshmasligi kerak")]
    string? lastName,

    string phoneNumber,

    [Required(ErrorMessage =$"{ nameof(CreateApplicationDto.applicationMassage)}  berilishi majburiy")]
    [StringLength(300,ErrorMessage ="Ism 300 ta belgida oshmasligi kerak")]
    string applicationMassage,

    [Required(ErrorMessage =$"{nameof(CreateApplicationDto.email)} berilishi majburiy")]
    [EmailAddress(ErrorMessage ="noto'g'ri email berildi ")]
    string email,

    [Required(ErrorMessage =$"{nameof(CreateApplicationDto.jobId)} berilishi majburiy")]
    Guid jobId,

    [Required(ErrorMessage =$"{nameof(CreateApplicationDto.createAddressDto)} berilishi majburiy")]
    CreateAddressDto createAddressDto);
