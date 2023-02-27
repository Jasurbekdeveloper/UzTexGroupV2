using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UzTexGroupV2.Application.EntitiesDto;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Application.QueryExtentions;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Domain.Exceptions;
using UzTexGroupV2.Infrastructure.DbContexts;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Application.Services;

public class ApplicationService
{
    private readonly LocalizedUnitOfWork unitOfWork;
    private readonly AddressService addressService;
    private readonly UzTexGroupDbContext uzTexGroupDbContext;
    private readonly IHttpContextAccessor httpContextAccessor;

    public ApplicationService(
        LocalizedUnitOfWork unitOfWork,
        AddressService addressService,
        UzTexGroupDbContext uzTexGroupDbContext,
        IHttpContextAccessor httpContextAccessor)
    {
        this.unitOfWork = unitOfWork;
        this.addressService = addressService;
        this.uzTexGroupDbContext = uzTexGroupDbContext;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async ValueTask<ApplicationDto> CreateApplicationAsync(
        CreateApplicationDto createApplicationDto)
    {
        Applications storedApplication = new Applications();

        var executionStrategy = uzTexGroupDbContext.Database.CreateExecutionStrategy();
        await executionStrategy.ExecuteAsync(async () =>
        {
            using (var transaction = uzTexGroupDbContext.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    var application = ApplicationMap.MapToApplication(createApplicationDto);

                    var storedAddress = await this.addressService
                        .CreateAddressAsync(createApplicationDto.createAddressDto);

                    application.AddressId = storedAddress.id;

                    storedApplication = await this.unitOfWork
                        .ApplicationRepository.CreateAsync(application);

                    await this.unitOfWork.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new InValidEntityException(
                        "Application yoki address ma'lumotlarida xatolik sodir bo'ldi");
                }
            }
        });
        return ApplicationMap.MapToApplicationDto(storedApplication);
    }

    public async ValueTask<IQueryable<ApplicationDto>> RetrieveAllApplicationsAsync(
        QueryParameter queryParameter)
    {
        var storageApplications = await this
            .unitOfWork.ApplicationRepository.GetAllAsync();

        var paginatedAplication = storageApplications.PagedList(
           httpContext: httpContextAccessor.HttpContext,
           queryParameter: queryParameter);

        return paginatedAplication.Select(
            application => ApplicationMap.MapToApplicationDto(application));
    }

    public async ValueTask<ApplicationDto> RetrieveApplicationByIdAsync(Guid id)
    {
        var storageApplication = await GetByExpressionAsync(id);

        return ApplicationMap.MapToApplicationDto(storageApplication);
    }

    public async ValueTask<ApplicationDto> ModifyApplicationAsync(
        ModifyApplicationDto modifyApplicationDto)
    {
        Applications modifiedApplication = new Applications();

        var executionStrategy = uzTexGroupDbContext.Database.CreateExecutionStrategy();
        await executionStrategy.ExecuteAsync(async () =>
        {
            using (var transaction = uzTexGroupDbContext.Database.BeginTransaction(IsolationLevel.Serializable))
            {
                try
                {
                    var storageApplication = await GetByExpressionAsync(modifyApplicationDto.id);

                    if (modifyApplicationDto.modifyAddressDto is not null)
                        await this.addressService
                            .ModifyAddressAsync(modifyApplicationDto.modifyAddressDto);

                    ApplicationMap.MapToApplication(applications: storageApplication,
                        modifyApplicationDto: modifyApplicationDto);

                    modifiedApplication = await this.unitOfWork.ApplicationRepository.UpdateAsync(
                        entity: storageApplication);

                    await this.unitOfWork.SaveChangesAsync();
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new InValidEntityException("Address yoki Application ma'lumotlarida xatolik bor");
                }
            }
        });

        return ApplicationMap.MapToApplicationDto(modifiedApplication);
    }

    public async ValueTask<ApplicationDto> DeleteApplicationAsync(Guid id)
    {
        var storageApplication = await GetByExpressionAsync(id);

        var deletedApplication = await this.unitOfWork.ApplicationRepository
            .DeleteAsync(storageApplication);

        await this.unitOfWork.SaveChangesAsync();

        return ApplicationMap.MapToApplicationDto(deletedApplication);
    }

    private async ValueTask<Applications> GetByExpressionAsync(Guid id)
    {
        Validations.ValidateId(id);

        var applications = await this.unitOfWork.ApplicationRepository
           .GetByExpression(
            expression => expression.Id == id,
            new string[] {"Job", "Address"});

        var application = await applications.FirstOrDefaultAsync();

        Validations.ValidateObjectForNullable<Applications>(application);

        return application;

    }
}
