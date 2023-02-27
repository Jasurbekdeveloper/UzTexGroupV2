namespace UzTexGroupV2.Domain.Exceptions;

public class InvalidRefreshTokenException : Exception
{
	public InvalidRefreshTokenException(string message)
		: base(message)
	{
	}
}
