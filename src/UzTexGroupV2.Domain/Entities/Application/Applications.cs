namespace UzTexGroupV2.Domain.Entities;

public class Applications : LocalizedObject
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public Guid AddressId { get; set; }
    public string ApplicationMessage { get; set; }
    public Guid JobId { get; set; }
    public Job Job { get; set; }
    
    public Address? Address { get; set; }

}
