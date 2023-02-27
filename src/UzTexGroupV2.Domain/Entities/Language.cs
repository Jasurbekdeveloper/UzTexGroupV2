namespace UzTexGroupV2.Domain.Entities;

public class Language
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }

    public Language()
    {
        Code = "uz";
        Name = "uzbek";
    }
}