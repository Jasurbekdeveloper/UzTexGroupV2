using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Controllers;

[Route("{langCode}/api/[controller]")]
[ApiController]
public class ApplicationController : LocalizedControllerBase
{
    private readonly ApplicationService applicationService;
    public ApplicationController(LocalizedUnitOfWork localizedUnitOfWork,
        ApplicationService applicationService) : base(localizedUnitOfWork)
    {
        this.applicationService = applicationService;
    }

    [AllowAnonymous]
    [HttpPost]
    public async ValueTask<ActionResult<ApplicationDto>> PostApplicationAsync(
        CreateApplicationDto createApplicationDto)
    {
        var createdApplication = await this.applicationService
            .CreateApplicationAsync(createApplicationDto);

        return Created("", createdApplication);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("id: Guid")]
    public async ValueTask<ActionResult<ApplicationDto>> GetApplicationByIdAsync(
        Guid applicationId)
    {
        var Application = await this.applicationService
            .RetrieveApplicationByIdAsync(applicationId);

        return Ok(Application);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async ValueTask<IActionResult> GetAllApplicationesAsync(
       [FromQuery] QueryParameter queryParameter)
    {
        var Applicationes = await this.applicationService
            .RetrieveAllApplicationsAsync(queryParameter);

        return Ok(Applicationes);
    }

    [AllowAnonymous]
    [HttpPut]
    public async ValueTask<ActionResult<ApplicationDto>> PutApplicationAsync(
        ModifyApplicationDto modifyApplicationDto)
    {
        var updatedApplication = await this.applicationService
            .ModifyApplicationAsync(modifyApplicationDto);

        return Ok(updatedApplication);
    }

    [AllowAnonymous]
    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<ApplicationDto>> DeleteApplicationAsync(Guid id)
    {
        var deletedApplication = await this.applicationService
            .DeleteApplicationAsync(id);

        return Ok(deletedApplication);
    }
}
