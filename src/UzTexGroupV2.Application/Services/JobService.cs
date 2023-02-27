using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Application.QueryExtentions;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Application.Services;

public class JobService
{
    private readonly LocalizedUnitOfWork localizedUnitOfWork;
    private readonly IHttpContextAccessor httpContextAccessor;

    public JobService(LocalizedUnitOfWork localizedUnitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        this.localizedUnitOfWork = localizedUnitOfWork;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async ValueTask<JobDto> CreateJobAsync(CreateJobDto createJobDto)
    {
        var job = JobMap.MapToJob(createJobDto);

        var storagefactory = await this.localizedUnitOfWork.FactoryRepository
            .GetByExpression(
            factory => factory.Id == createJobDto.FactoryId,
            new string[] {});

        Validations.ValidateObjectForNullable(await storagefactory.FirstOrDefaultAsync());

        var storedJob = await this.localizedUnitOfWork
            .JobRepository.CreateAsync(job);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return JobMap.MapToJobDto(storedJob);
    }

    public async ValueTask<IQueryable<JobDto>> RetrieveAllJobsAsync(
        QueryParameter queryParameter)
    {
        var jobs = await this.localizedUnitOfWork.JobRepository
            .GetAllAsync();
        //
        // if (queryParameter.Search is not null)
        //     jobs = jobs
        //         .Where();
        
        var paginationJojs = jobs.PagedList(
            httpContext: httpContextAccessor.HttpContext,
            queryParameter: queryParameter);

        return paginationJojs.Select(job => JobMap.MapToJobDto(job));
    }
    public async ValueTask<JobDto> RetrieveJobByIdAsync(Guid id)
    {
        var storageJob = await GetByExpressionAsync(id);

        return JobMap.MapToJobDto(storageJob);
    }

    public async ValueTask<JobDto> ModifyJobAsync(ModifyJobDto modifyJobDto)
    {
        var storageJob = await GetByExpressionAsync(modifyJobDto.Id);

        var storagefactory = await this.localizedUnitOfWork.FactoryRepository
           .GetByExpression(
           factory => factory.Id == modifyJobDto.FactoryId,
           new string[] { });

        Validations.ValidateObjectForNullable(await storagefactory.FirstOrDefaultAsync());

        JobMap.MapToJob(storageJob, modifyJobDto);

        var job = await this.localizedUnitOfWork.JobRepository
            .UpdateAsync(storageJob);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return JobMap.MapToJobDto(job : job);
    }

    public async ValueTask<JobDto> DeleteJobAsync(Guid id)
    {
        var storageJob = await GetByExpressionAsync(id);

        var deletedJob = await this.localizedUnitOfWork.JobRepository
            .DeleteAsync(storageJob);

        await this.localizedUnitOfWork.SaveChangesAsync();

        return JobMap.MapToJobDto(deletedJob);
    }
    private async ValueTask<Job> GetByExpressionAsync(Guid id)
    {
        Validations.ValidateId(id);

        var jobs = await this.localizedUnitOfWork.JobRepository
           .GetByExpression(
            expression => expression.Id == id,
            new string[] { "Factory"});

        var job = await jobs.FirstOrDefaultAsync();

        Validations.ValidateObjectForNullable(job);

        return job;

    }
}