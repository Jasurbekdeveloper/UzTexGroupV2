using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto.Company;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Controllers;

[Route("{langCode}/api/[controller]")]
[ApiController]
public class CompanyController : LocalizedControllerBase
{
    private readonly CompanyService companyService;
    public CompanyController(LocalizedUnitOfWork localizedUnitOfWork,
        CompanyService companyService) : base(localizedUnitOfWork)
    {
        this.companyService = companyService;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async ValueTask<ActionResult<CompanyDTO>> PostCompanyAsync(
        CreateCompanyDTO createCompanyDTO)
    {
        var createdCompany = await this.companyService
            .CreateCompanyAsync(createCompanyDTO);

        return Created("", createdCompany);
    }
    [AllowAnonymous]
    [HttpGet("id: Guid")]
    public async ValueTask<ActionResult<CompanyDTO>> GetCompanyByIdAsync(
        Guid id)
    {
        var company = await this.companyService
            .RetrieveCompanyByIdAsync(id);

        return Ok(company);
    }

    [AllowAnonymous]
    [HttpGet]
    public async ValueTask<IActionResult> GetallCompaniesAsync(
        [FromQuery] QueryParameter queryParameter)
    {
        var companies = await this.companyService
            .RetrieveAllCompnaiesAsync(queryParameter);

        return Ok(companies);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async ValueTask<ActionResult<CompanyDTO>> UpdateCompanyAsync(
        ModifyCompanyDTO modifyCompanyDTO)
    {
        var updatedCompany = await this.companyService
            .ModifyCompanyAsync(modifyCompanyDTO);

        return Ok(updatedCompany);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<CompanyDTO>> DeleteAdressAsync(Guid id)
    {
        var deletedAdress = await this.companyService
            .DeleteCompanyAsync(id);
        return Ok(deletedAdress);
    }
}
