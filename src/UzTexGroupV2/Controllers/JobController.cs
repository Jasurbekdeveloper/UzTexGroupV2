using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.EntitiesDto.Addresses;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Controllers;

[Route("{langCode}/api/[controller]")]
[ApiController]
public class JobController : LocalizedControllerBase
{
    private readonly JobService jobService;
    public JobController(LocalizedUnitOfWork localizedUnitOfWork,
        JobService jobService) : base(localizedUnitOfWork)
    {
        this.jobService = jobService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async ValueTask<ActionResult<JobDto>> PostJobAsync(
        CreateJobDto createJobDto)
    {
        var createdJob = await this.jobService
            .CreateJobAsync(createJobDto);

        return Created("", createdJob);
    }

    [AllowAnonymous]
    [HttpGet("id: Guid")]
    public async ValueTask<ActionResult<JobDto>> GetJobByIdAsync(
        Guid jobId)
    {
        var Job = await this.jobService
            .RetrieveJobByIdAsync(jobId);

        return Ok(Job);
    }

    [AllowAnonymous]
    [HttpGet]
    public async ValueTask<IActionResult> GetallJobesAsync(
        [FromQuery] QueryParameter queryParameter)
    {
        var jobs = await this.jobService
            .RetrieveAllJobsAsync(queryParameter);

        return Ok(jobs);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async ValueTask<ActionResult<JobDto>> PutJobAsync(
        ModifyJobDto modifyJobDto)
    {
        var updatedJob = await this.jobService
            .ModifyJobAsync(modifyJobDto);

        return Ok(updatedJob);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<JobDto>> DeleteAdressAsync(Guid jobId)
    {
        var deletedAdress = await this.jobService
            .DeleteJobAsync(jobId);
        return Ok(deletedAdress);
    }
}
