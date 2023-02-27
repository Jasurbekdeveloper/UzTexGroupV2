using UzTexGroupV2.Application.EntitiesDto.Factory;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.MappingProfiles;

internal static class FactoryMap
{
    internal static FactoryDto MapToFactoryDto(Factory factory)
    {
        return new FactoryDto(
            id: factory.Id,
            name: factory.Name,
            companyDTO: factory.Company is not null ? CompanyMapper.ToCompanyDTO(factory.Company) : null,
            addressDto: factory.Address is not null ? AddressMap.MapToAddressDto(factory.Address) : null);
    }
    internal static void MapToFactory(Factory factory, ModifyFactoryDto modifyFactoryDto)
    {
        factory.Name = modifyFactoryDto.name ?? factory.Name;
        factory.CompanyId = modifyFactoryDto.companyId ?? factory.CompanyId;
    }

    internal static Factory MapToFactory(CreateFactoryDto createFactoryDto)
    {
        return new Factory
        {
            Id = createFactoryDto.Id ?? Guid.NewGuid(),
            Name = createFactoryDto.name,
            CompanyId = createFactoryDto.companyId
        };
    }
}
