using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Addresses;

namespace UzTexGroupV2.Application.EntitiesDto.Factory;

public record CreateFactoryDto(
    [Required(ErrorMessage = $"{nameof(CreateFactoryDto.name)}  berilishi majburiy")]
    [StringLength(15, ErrorMessage = "Ism 15 ta belgida oshmasligi kerak")]
    string name,
    [Required(ErrorMessage = $"{nameof(CreateFactoryDto.companyId)}  berilishi majburiy")]
    Guid companyId,
    [Required(ErrorMessage = $"{nameof(CreateFactoryDto.createAddressDto)}  berilishi majburiy")]
    CreateAddressDto createAddressDto) : LocalizedDTO;
