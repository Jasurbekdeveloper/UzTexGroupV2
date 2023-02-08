namespace UzTexGroupV2.Domain.Exceptions;

public class InvalidIdException : Exception
{
	public InvalidIdException(string message) : base (message) 
	{
	}
}
