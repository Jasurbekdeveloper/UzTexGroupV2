using UzTexGroupV2.Domain.Entities;
using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class LocalizedUnitOfWork : UnitOfWorkBase
{
    public NewsRepository NewsRepository { get; private set; }
    public JobRepository JobRepository { get; private set; }
    public CompanyRepository CompanyRepository { get; private set; }
    public FactoryRepository FactoryRepository { get; private set; }
    public ApplicationRepository ApplicationRepository { get; private set; }
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
            .GetProperties();
        foreach (var propertyInfo in properties)
        {
            if (propertyInfo is null)
                continue;
            var languageProperty = propertyInfo
                .PropertyType?
                .BaseType?
                .GetProperty("Language");

            var data = (languageProperty.GetValue(this));

            languageProperty?
                .SetValue(this, language);
        }
    }
}
