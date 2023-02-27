using UzTexGroupV2.Domain.Enums;

namespace UzTexGroupV2.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Salt { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? ExpiredRefreshToken { get; set; }
    public Role UserRole { get; set; }
}
