using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Factory;

namespace UzTexGroupV2.Application.EntitiesDto;

public record JobDto(
    Guid id,
    string name,
    string workTime,
    decimal salary,
    string description,
    FactoryDto? factoryDto);
