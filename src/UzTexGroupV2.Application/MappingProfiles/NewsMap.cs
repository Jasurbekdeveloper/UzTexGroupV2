using UzTexGroupV2.Application.EntitiesDto.News;
using UzTexGroupV2.Application.Services;
using UzTexGroupV2.Domain.Entities;

namespace UzTexGroupV2.Application.MappingProfiles;

internal static class NewsMap
{
    internal static News MapToNews(CreateNewsDto createNewsDto)
    {
        Guid id = createNewsDto.Id ?? Guid.NewGuid();
        return new News
        {
            Id = id,
            Date = DateTime.Now,
            Title = createNewsDto.title,
            Description = createNewsDto.description
        };
    }
    internal static void MapToNews(ModifyNewsDto modifyNewsDto, News news)
    {
        news.Title = modifyNewsDto.title;
        news.Description = modifyNewsDto.description;
    }

    internal static NewsDto MapToNewsDto(News news)
    {
        return new NewsDto(
            id: news.Id,
            date: news.Date,
            title: news.Title,
            description: news.Description);
    }
}
