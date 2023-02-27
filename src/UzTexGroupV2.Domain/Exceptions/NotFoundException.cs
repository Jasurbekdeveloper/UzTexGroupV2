namespace UzTexGroupV2.Domain;

public class NotFoundException : Exception
{
	public NotFoundException(string message) : base(message)
	{
	}
}
