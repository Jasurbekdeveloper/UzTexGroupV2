using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.News;

public record ModifyNewsDto(
    [Required(ErrorMessage = $"{nameof(ModifyNewsDto.id)}  berilishi majburiy")]
    Guid id,

    string? title,
    string? description,
    IFormFile? file
);
