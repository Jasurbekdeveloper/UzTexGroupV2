using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class LocalizedUnitOfWork : UnitOfWorkBase
{
    public readonly NewsRepository NewsRepository;
    public readonly JobRepository JobRepository;
    public readonly CompanyRepository CompanyRepository;
    public readonly FactoryRepository FactoryRepository;
    public readonly ApplicationRepository ApplicationRepository;

    public LocalizedUnitOfWork(UzTexGroupDbContext uzTexGroupDbContext) : base(uzTexGroupDbContext)
    {
        this.NewsRepository = new NewsRepository(this.uzTexGroupDbContext);
        this.JobRepository = new JobRepository(this.uzTexGroupDbContext);
        this.CompanyRepository = new CompanyRepository(this.uzTexGroupDbContext);
        this.FactoryRepository = new FactoryRepository(this.uzTexGroupDbContext);
        this.ApplicationRepository = new ApplicationRepository(this.uzTexGroupDbContext);
    }

    public async ValueTask ChangeLocalization(Language? language)
    {
        if (language is null)
            language = new Language();
        var properties = this
            .GetType()
            .GetFields();
        foreach (var property in properties)
        {
            if (property is null)
                continue;
            var obj = property.GetValue(this);
            obj?
                .GetType()?
                .GetProperty("Language")?
                .SetValue(obj, language);
        }
    }
}