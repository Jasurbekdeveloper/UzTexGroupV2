using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Application.EntitiesDto.Company;

namespace UzTexGroupV2.Application.EntitiesDto.Factory;

public record FactoryDto(
    [Required(ErrorMessage =$"{ nameof(FactoryDto.id)}  berilishi majburiy")]
    Guid id,
    [Required(ErrorMessage = $"{nameof(FactoryDto.name)}  berilishi majburiy")]
    [StringLength(15, ErrorMessage = "Ism 15 ta belgida oshmasligi kerak")]
    string name,

    CompanyDTO? companyDTO,
    AddressDto? addressDto);
