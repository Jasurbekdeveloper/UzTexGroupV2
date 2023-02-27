using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.Company;

public record ModifyCompanyDTO(
    [Required(ErrorMessage = $"{nameof(ModifyCompanyDTO.id)}  berilishi majburiy")]
    Guid id,

    [Required(ErrorMessage = $"{nameof(ModifyCompanyDTO.name)}  berilishi majburiy")]
    [StringLength(15, ErrorMessage = "Ism 15 ta belgida oshmasligi kerak")]
    string? name
);