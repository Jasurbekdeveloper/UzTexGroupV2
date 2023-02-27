using System.Security.Cryptography;
using System.Text;

namespace UzTexGroupV2.Infrastructure.Authentication;

public class PasswordHasher : IPasswordHasher
{
    private const int KeySize = 32;
    private const int IterationCount = 1000;
    public string GeneratePassword(string password, string salt)
    {
        using (var algoritm = new Rfc2898DeriveBytes(
            password, Encoding.UTF8.GetBytes(salt),
            iterations: IterationCount,
            hashAlgorithm: HashAlgorithmName.SHA256))

        {
            return Convert.ToBase64String(algoritm.GetBytes(KeySize));   
        }
    }

    public bool VerifyPassword(string password, string salt, string hash)
    {
        var a = GeneratePassword(password, salt);

        return a.SequenceEqual(hash);


    }
}
