using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto;

public record ModifyJobDto
{
    [Required(ErrorMessage = $"{nameof(ModifyJobDto.Id)}  berilishi majburiy")]
    public Guid Id { get; set; }


    [StringLength(15, ErrorMessage = "Ism 15 ta belgida oshmasligi kerak")]
    public string? Name { get; set; }
    public string? Desription { get; set; }
    public string? WorkTime { get; set; }
    public decimal? Salary { get; set; }
    public Guid? FactoryId { get; set; }
}