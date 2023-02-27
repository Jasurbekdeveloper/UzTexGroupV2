using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.MappingProfiles
{
    public static class AddressMap
    {
        public static Address MapToAddress(
            CreateAddressDto createAddressDto)
        {
            return new Address
            {
                Id = Guid.NewGuid(),
                Country = createAddressDto.country,
                Region= createAddressDto.region,
                District= createAddressDto.district,
                Street = createAddressDto.street,
                PostalCode= createAddressDto.postalCode,     
            };
        }
        public static AddressDto MapToAddressDto(Address address) =>
            new AddressDto(address.Id, address.Country, address.Region,
                address.District, address.Street,address.PostalCode);

        public static void MapToAddress(ModifyAddressDto modifyAddressDto, Address address)
        {
            address.Country = modifyAddressDto.country ?? address.Country;  
            address.Region = modifyAddressDto.region ?? address.Region;
            address.District = modifyAddressDto.district ?? address.District;
            address.Street = modifyAddressDto.street ?? address.Street;
            address.PostalCode = modifyAddressDto.postalCode ?? address.PostalCode;
        }
    }
}
