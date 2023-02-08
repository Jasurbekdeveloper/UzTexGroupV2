using UzTexGroupV2.Domain.Exceptions;

namespace UzTexGroupV2.Application.Services;

public static class Validations
{
    public static void ValidateId(Guid id)
    {
        if (id == default)
            throw new InvalidIdException("Bu id yaroqli emas!");
    }
    public static void ValidateObject<T>(T entity)
    {
        if (entity is null)
            throw new NotFoundException($"{nameof(entity)} ob'ekt topilmadi");
    }
}
