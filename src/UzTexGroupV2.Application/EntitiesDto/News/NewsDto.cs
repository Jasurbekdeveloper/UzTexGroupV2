using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.News;

public record NewsDto(
    Guid id,
    DateTime date,
    string title,
    string description);