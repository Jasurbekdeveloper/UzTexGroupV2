namespace UzTexGroupV2.Domain;

public class InvalidIdException : Exception
{
	public InvalidIdException(string message) : base (message) 
	{
	}
}
