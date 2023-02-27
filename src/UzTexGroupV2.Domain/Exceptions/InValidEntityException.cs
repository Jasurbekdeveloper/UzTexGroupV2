namespace UzTexGroupV2.Domain.Exceptions;

public class InValidEntityException : Exception
{
	public InValidEntityException(string message)
		: base(message)
	{

	}
}
