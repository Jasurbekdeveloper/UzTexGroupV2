using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto;

public record ApplicationDto(
    Guid id,
    string firstName,
    string? lastName,
    string phoneNumber,
    string applicationMassage,
    string email,
    JobDto? job,
    AddressDto addressDto);