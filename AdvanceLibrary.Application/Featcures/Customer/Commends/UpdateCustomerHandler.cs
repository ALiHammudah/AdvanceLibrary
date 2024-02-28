using AdvanceLibrary.Application.Contract.Repositries;
using AdvanceLibrary.Domain.Commends.Customer;
using AdvanceLibrary.Domain.Dtos.Customer;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Customer.Commends;
public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, GetCustomerViewDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public UpdateCustomerHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<GetCustomerViewDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Customer.UpdateCustomerAsync(request);
    }
}
