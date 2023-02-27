using System.Net.Http.Headers;
using UzTexGroupV2.Domain;

namespace UzTexGroupV2.Application.Services;

public static class Validations
{
    public static void ValidateId(Guid id)
    {
        if (id == default)
            throw new InvalidIdException("Bu id yaroqli emas!");
    }
    public static void ValidateObjectForNullable<T>(T entity)
    {
        if (entity is null)
            throw new NotFoundException($"{typeof(T)} ob'ekt topilmadi");
    }
}
