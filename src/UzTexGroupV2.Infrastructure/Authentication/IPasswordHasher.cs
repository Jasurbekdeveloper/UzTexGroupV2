namespace UzTexGroupV2.Infrastructure.Authentication;

public interface IPasswordHasher
{
    string GeneratePassword(string password, string salt);

    bool VerifyPassword(string password, string salt, string hash);
}
