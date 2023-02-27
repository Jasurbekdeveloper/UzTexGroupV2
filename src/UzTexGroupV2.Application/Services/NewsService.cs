using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using UzTexGroupV2.Application.EntitiesDto.News;
using UzTexGroupV2.Application.MappingProfiles;
using UzTexGroupV2.Application.QueryExtentions;
using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.Repositories;
using UzTexGroupV2.Model;

namespace UzTexGroupV2.Application.Services;

public class NewsService
{
    private readonly LocalizedUnitOfWork lacalizedUnitOfWork;
    private readonly IHttpContextAccessor httpContextAccessor;

    public NewsService(
        LocalizedUnitOfWork lacalizedUnitOfWork,
        IHttpContextAccessor httpContextAccessor)
    {
        this.lacalizedUnitOfWork = lacalizedUnitOfWork;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async ValueTask<NewsDto> CreateNewsAsync(CreateNewsDto createNews)
    {
        var news = NewsMap.MapToNews(createNews);

        ImagesService.SaveImage(createNews.file, 
            news.Id.ToString(), 
            this.lacalizedUnitOfWork.NewsRepository.Language.Code);
        
        var storageNews = await this.lacalizedUnitOfWork
            .NewsRepository.CreateAsync(news);

        await this.lacalizedUnitOfWork.SaveChangesAsync();

        return NewsMap.MapToNewsDto(storageNews);
    }

    public async ValueTask<IQueryable<NewsDto>> RetrieveAllNewssAsync(
        QueryParameter queryParameter)
    {
        var newss = await this.lacalizedUnitOfWork.NewsRepository.GetAllAsync();

        var paginationNews = newss.PagedList(
            httpContext: httpContextAccessor.HttpContext,
            queryParameter: queryParameter);

        return paginationNews.Select(news => NewsMap.MapToNewsDto(news));
    }

    public async ValueTask<NewsDto> RetrieveNewsByIdAsync(Guid Id)
    {
        var storageNews = await GetByExpressionAsync(Id);

        return NewsMap.MapToNewsDto(storageNews);
    }

    public async ValueTask<NewsDto> ModifyNewsAsync(ModifyNewsDto modifyNewsDto)
    {
        var storageNews = await GetByExpressionAsync(modifyNewsDto.id);

        NewsMap.MapToNews(
            modifyNewsDto: modifyNewsDto,
            news: storageNews);

        var modeifiedNews = await this.lacalizedUnitOfWork.NewsRepository
            .UpdateAsync(storageNews);

        await this.lacalizedUnitOfWork.SaveChangesAsync();

        return NewsMap.MapToNewsDto(modeifiedNews);
    }
    public async ValueTask<NewsDto> DeleteNewsAsync(Guid Id)
    {
        var storageNews = await GetByExpressionAsync(Id);

        var deletedNews = await this.lacalizedUnitOfWork.NewsRepository
            .DeleteAsync(storageNews);

        await this.lacalizedUnitOfWork.SaveChangesAsync();

        return NewsMap.MapToNewsDto(deletedNews);
    }
    private async ValueTask<News> GetByExpressionAsync(Guid id)
    {
        Validations.ValidateId(id);

        var newss = await this.lacalizedUnitOfWork.NewsRepository
           .GetByExpression(expression => expression.Id == id, new string[] { });

        var news = await newss.FirstOrDefaultAsync();

        Validations.ValidateObjectForNullable(news);

        return news;
    }
}
