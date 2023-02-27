using System.ComponentModel.DataAnnotations;

namespace UzTexGroupV2.Application.EntitiesDto;

public record CreateJobDto : LocalizedDTO
{
    [Required(ErrorMessage = $"{nameof(CreateJobDto.Name)}  berilishi majburiy")]
    [StringLength(15, ErrorMessage = "Ism 15 ta belgida oshmasligi kerak")]
    public string Name { get; set; }

    [Required(ErrorMessage = $"{nameof(CreateJobDto.Desription)}  berilishi majburiy")]
    public string Desription { get; set; }

    [Required(ErrorMessage = $"{nameof(CreateJobDto.WorkTime)}  berilishi majburiy")]
    public string WorkTime { get; set; }
    [Required(ErrorMessage = $"{nameof(CreateJobDto.Salary)}  berilishi majburiy")]
    public decimal Salary { get; set; }
    [Required(ErrorMessage = $"{nameof(CreateJobDto.FactoryId)}  berilishi majburiy")]
    public Guid FactoryId { get; set; }
}