using UzTexGroupV2.Infrastructure.DbContexts;

namespace UzTexGroupV2.Infrastructure.Repositories;

public class UnitOfWork : UnitOfWorkBase
{
    public readonly UserRepository UserRepository;
    public readonly AddressRepository AddressRepository;

    public UnitOfWork(UzTexGroupDbContext uzTexGroupDbContext) : base(uzTexGroupDbContext)
    {
        this.UserRepository = new UserRepository(this.uzTexGroupDbContext);
        this.AddressRepository = new AddressRepository(this.uzTexGroupDbContext);
    }
}