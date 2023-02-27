using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Domain.Enums;

namespace UzTexGroupV2.Application.EntitiesDto;

public record UserDto(
    Guid id,
    string firstName,
    string lastName,
    string email,
    Role role);