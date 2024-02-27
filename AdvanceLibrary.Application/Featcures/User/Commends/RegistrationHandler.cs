using AdvanceLibrary.Domain.Commends.User;
using AdvanceLibrary.Domain.Dtos.Auth;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.User.Commends;
public class RegistrationHandler : IRequestHandler<RegistrationCommand, AuthDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public RegistrationHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<AuthDto> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Auth.RegisterAsync(request);
    }
}
