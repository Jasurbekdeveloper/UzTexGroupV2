using Microsoft.EntityFrameworkCore;
using Moq;
using UzTexGroupV2.Application.EntitiesDto.Company;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;
using UzTexGroupV2.Infrastructure.Repositories;


namespace UztexGroupV2.Test.Services;

public class TestCompany
{
    [Fact]
    public async void CreateCompany()
    {
        var dbContext = new Mock<UzTexGroupDbContext>(null);
        var localizedUnitOfWork = new Mock<LocalizedUnitOfWork>(dbContext.Object);
        var companyService = new Mock<CompanyService>(localizedUnitOfWork.Object).Object;
               
        var companyDto = new CreateCompanyDTO()
        {
            Name = "Uz tex",
            LanguageCode = "uz"
        };
        
        var storedCompany = await companyService
            .CreateEntityAsync(companyDto);
        
        Assert.NotNull(storedCompany);
        Assert.NotNull(storedCompany.Id);
        Assert.NotNull(storedCompany.Name);
    }
}
