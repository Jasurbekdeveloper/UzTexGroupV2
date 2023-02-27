using System.Collections;
using System.ComponentModel.DataAnnotations;
using UzTexGroupV2.Application.EntitiesDto.Factory;

namespace UzTexGroupV2.Application.EntitiesDto.Company;

public record CompanyDTO(
    Guid id,
    string name);

