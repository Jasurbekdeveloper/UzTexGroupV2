using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Application.EntitiesDto.Company;

namespace UzTexGroupV2.Application.EntitiesDto.Factory;

public record FactoryDto(
    Guid id,
    string name,
    CompanyDTO? companyDTO,
    AddressDto? addressDto);
