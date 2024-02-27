using AdvanceLibrary.Domain.Dtos.Auth;
using MediatR;

namespace AdvanceLibrary.Domain.Queries.User;
public record LoginQuery(string Email, string Password) : IRequest<AuthDto>;
