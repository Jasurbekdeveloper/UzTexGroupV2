using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UzTexGroupV2.Application.EntitiesDto.News;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Controllers;

[Route("{langCode}/api/[controller]")]
[ApiController]
public class NewsController : LocalizedControllerBase
{
    private readonly NewsService newsService;
    private readonly IWebHostEnvironment webHostEnvironment;
    public NewsController(LocalizedUnitOfWork localizedUnitOfWork,
        NewsService newsService,
        IWebHostEnvironment webHostEnvironment) : base(localizedUnitOfWork)
    {
        this.newsService = newsService;
        this.webHostEnvironment = webHostEnvironment;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async ValueTask<ActionResult<NewsDto>> PostNewsAsync(
        [FromForm] CreateNewsDto createNewsDto)
    {
        var createdNews = await this.newsService
            .CreateNewsAsync(createNewsDto);

        return Created("", createdNews);
    }

    [AllowAnonymous]
    [HttpGet("id: Guid")]
    public async ValueTask<ActionResult<NewsDto>> GetNewsByIdAsync(
        Guid newsId)
    {
        var News = await this.newsService
            .RetrieveNewsByIdAsync(newsId);

        return Ok(News);
    }

    [AllowAnonymous]
    [HttpGet]
    public async ValueTask<IActionResult> GetallNewsesAsync(
        [FromQuery] QueryParameter queryParameter)
    {
        var Newses = await this.newsService
            .RetrieveAllNewssAsync(queryParameter);

        return Ok(Newses);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async ValueTask<ActionResult<NewsDto>> PutNewsAsync(
        [FromForm] ModifyNewsDto modifyNewsDto)
    {
        var updatedNews = await this.newsService
            .ModifyNewsAsync(modifyNewsDto);

        return Ok(updatedNews);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("id : Guid")]
    public async ValueTask<ActionResult<NewsDto>> DeleteAdressAsync(Guid newsId)
    {
        var deletedAdress = await this.newsService
            .DeleteNewsAsync(newsId);
        return Ok(deletedAdress);
    }
}
