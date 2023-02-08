using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto.Company;

public record CreateCompanyDTO : LocalizedDTO
{
    public Guid? Id { get; set; }

    [Required(ErrorMessage = $"{nameof(CreateCompanyDTO.Name)}  berilishi majburiy")]
    [StringLength(15, ErrorMessage = "Ism 15 ta belgida oshmasligi kerak")]
    public string Name { get; set; }
}
