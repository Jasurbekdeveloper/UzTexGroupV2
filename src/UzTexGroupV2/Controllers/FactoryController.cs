using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto.Factory;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Controllers;

[Route("{langCode}/api/[controller]")]
[ApiController]
public class FactoryController : LocalizedControllerBase
{
    private readonly FactoryService factoryService;
    public FactoryController(LocalizedUnitOfWork localizedUnitOfWork,
        FactoryService factoryService) : base(localizedUnitOfWork)
    {
        this.factoryService = factoryService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async ValueTask<ActionResult<FactoryDto>> PostFactoryAsync(
        CreateFactoryDto createFactoryDto)
    {
        var createdFactory = await this.factoryService
            .CreateFactoryAsync(createFactoryDto);

        return Created("", createdFactory);
    }
    [AllowAnonymous]
    [HttpGet("id: Guid")]
    public async ValueTask<ActionResult<FactoryDto>> GetFactoryByIdAsync(
        Guid factoryId)
    {
        var factory = await this.factoryService
            .RetrieveFactoryByIdAsync(factoryId);

        return Ok(factory);
    }

    [AllowAnonymous]
    [HttpGet]
    public async ValueTask<IActionResult> GetallFactoryesAsync(
        [FromQuery] QueryParameter queryParameter)
    {
        var factories = await this.factoryService
            .RetrieveAllFactoriesAsync(queryParameter);

        return Ok(factories);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async ValueTask<ActionResult<FactoryDto>> PutFactoryAsync(
        ModifyFactoryDto modifyfactoryDto)
    {
        var updatedfactory = await this.factoryService
            .ModifyFactoryAsync(modifyfactoryDto);

        return Ok(updatedfactory);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<FactoryDto>> DeleteFactoryAsync(Guid id)
    {
        var deletedAdress = await this.factoryService
            .DeleteFactoryAsync(id);

        return Ok(deletedAdress);
    }
}
