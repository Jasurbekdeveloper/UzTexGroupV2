using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.Addresses;
public record AddressDto(
     Guid id,
    string country,
    string region,
    string district,
    string street,
    short postalCode);