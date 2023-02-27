namespace UzTexGroupV2.Domain.Exceptions;

public class InvalidEmailException : Exception
{
	public InvalidEmailException(string message)
		: base(message)
	{

	}
}
