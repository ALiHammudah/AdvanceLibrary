using AdvanceLibrary.Application.Contract.Repositries;
using AdvanceLibrary.Domain.Dtos.Library;
using AdvanceLibrary.Domain.Queries.CustomerBook;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.BookCustomer.Queries;
public class GetAllBorrowedHandler : IRequestHandler<GetAllBorrowedQuery, List<BorrowedBookDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllBorrowedHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<List<BorrowedBookDto>> Handle(GetAllBorrowedQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.BorrowedBook.GetAllBorrowedAsync();
    }
}
