using AdvanceLibrary.Domain.Commends.Customer;
using AdvanceLibrary.Domain.Dtos.Customer;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Customer.Commends;
public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, CustomerDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteCustomerHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<CustomerDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Customer.DeleteCustomerAsync(request.Id);
    }
}
