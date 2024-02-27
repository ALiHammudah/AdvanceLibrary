using AdvanceLibrary.Domain.Dtos.Customer;
using AdvanceLibrary.Domain.Queries.Customer;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Customer.Queries;
public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, List<CustomerDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllCustomerHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<List<CustomerDto>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Customer.GetAllCustomerAsync();
    }
}
