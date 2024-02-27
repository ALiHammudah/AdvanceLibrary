using AdvanceLibrary.Domain.Commends.User;
using AdvanceLibrary.Domain.Dtos.Auth;
using AdvanceLibrary.Domain.Queries.User;

namespace AdvanceLibrary.Application.Contract;
public interface IAuthServices
{
    Task<AuthDto> RegisterAsync(RegistrationCommand models);

    Task<AuthDto> LoginAsync(LoginQuery models);
}
