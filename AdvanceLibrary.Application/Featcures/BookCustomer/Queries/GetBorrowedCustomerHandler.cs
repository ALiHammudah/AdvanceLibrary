using AdvanceLibrary.Domain.Dtos.Library;
using AdvanceLibrary.Domain.Queries.CustomerBook;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.BookCustomer.Queries;
public class GetBorrowedCustomerHandler : IRequestHandler<GetBorrowedCustomerQuery, BorrowedCustomerDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetBorrowedCustomerHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<BorrowedCustomerDto> Handle(GetBorrowedCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.BorrowedBook.GetBorrowedcustomerAsync(request.CustomerName);
    }
}
