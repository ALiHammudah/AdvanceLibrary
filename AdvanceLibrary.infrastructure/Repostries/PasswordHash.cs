using AdvanceLibrary.Application.Contract.Serviese;
using System.Security.Cryptography;

namespace AdvanceLibrary.infrastructure.Repostries;
public class PasswordHash : IPasswordHash
{
    private int SaltSize = 128 / 8;
    private int KeySize = 256 / 8;
    private int Iterations = 10000;
    private static readonly HashAlgorithmName AlgorithmName = HashAlgorithmName.SHA256;
    private char Delimiter = ';';
    public string Hash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, AlgorithmName, KeySize);

        return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public bool Verify(string passwordHash, string password)
    {
        var elements = passwordHash.Split(Delimiter);

        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);

        var hashin = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, AlgorithmName, KeySize);

        return CryptographicOperations.FixedTimeEquals(hash, hashin);
    }
}
