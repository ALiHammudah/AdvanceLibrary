using AdvanceLibrary.Domain.Dtos.Auth;
using MediatR;

namespace AdvanceLibrary.Domain.Commends.User;
public record RegistrationCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password
    ) : IRequest<AuthDto>;
