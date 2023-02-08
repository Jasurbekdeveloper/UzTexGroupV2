using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Filters;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Controllers;

[Controller]
[Route("/{langCode}/[controller]")]
public class UserController : LocalizedControllerBase
{
    private readonly IHttpContextAccessor _contextAccessor;
    public UserController(LocalizedUnitOfWork localizedUnitOfWork, IHttpContextAccessor contextAccessor) : base(
        localizedUnitOfWork)
    {
        this._contextAccessor = contextAccessor;
    }

    [HttpGet("/{name}")]
    [ResponeFilter]
    public IActionResult GetData(string name)
    {
        return StatusCode(200, name);
    }
}
