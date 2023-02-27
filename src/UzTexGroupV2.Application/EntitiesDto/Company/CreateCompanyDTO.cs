using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UzTexGroupV2.Application.EntitiesDto.Company;

public record CreateCompanyDTO(
    [Required(ErrorMessage = $"{nameof(CreateCompanyDTO.name)}  berilishi majburiy")]
    [StringLength(15, ErrorMessage = "Ism 15 ta belgida oshmasligi kerak")]
    string name
) : LocalizedDTO;
