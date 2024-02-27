using AdvanceLibrary.Domain.Dtos.Customer;
using AdvanceLibrary.Domain.Queries.Customer;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Customer.Queries;
public class GetCustomerditailHandler : IRequestHandler<GetCustomerditailQuery, GetCustomerViewDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCustomerditailHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<GetCustomerViewDto> Handle(GetCustomerditailQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Customer.GetCustomerDitailAsync(request.id);
    }
}
