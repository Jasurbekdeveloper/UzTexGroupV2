namespace UzTexGroupV2.Domain.Exceptions;

public class ValidationQuery : Exception
{
    public ValidationQuery(string? message) : base(message)
    {
    }
}
