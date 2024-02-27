using AdvanceLibrary.Domain.Dtos.Library;
using AdvanceLibrary.Domain.Queries.CustomerBook;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.BookCustomer.Queries;
public class GetBorrowedBookHandler : IRequestHandler<GetBorrowedBookQuery, BorrowedBookDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetBorrowedBookHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<BorrowedBookDto> Handle(GetBorrowedBookQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.BorrowedBook.GetBorrowedBookAsync(request.BookName);
    }
}