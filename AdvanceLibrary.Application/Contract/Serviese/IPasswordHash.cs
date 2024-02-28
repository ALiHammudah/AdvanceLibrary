namespace AdvanceLibrary.Application.Contract.Serviese;
public interface IPasswordHash
{
    string Hash(string password);
    bool Verify(string passwordHash, string password);
}
