using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Infrastructure.Repositories;


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

    [HttpGet("{name}")]
    public IActionResult GetData(string name)
    {
        return StatusCode(200, this.localizedUnitOfWork.NewsRepository?.Language?.Code);
    }
}
