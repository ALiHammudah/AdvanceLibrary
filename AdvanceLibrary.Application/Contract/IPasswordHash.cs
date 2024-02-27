namespace AdvanceLibrary.Application.Contract;
public interface IPasswordHash
{
    string Hash(string password);
    bool Verify(string passwordHash, string password);
}
