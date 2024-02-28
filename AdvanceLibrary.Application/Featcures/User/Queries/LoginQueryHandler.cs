using AdvanceLibrary.Application.Contract.Repositries;
using AdvanceLibrary.Domain.Dtos.Auth;
using AdvanceLibrary.Domain.Queries.User;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.User.Queries;
public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public LoginQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
    public async Task<AuthDto> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Auth.LoginAsync(request);
    }
}
