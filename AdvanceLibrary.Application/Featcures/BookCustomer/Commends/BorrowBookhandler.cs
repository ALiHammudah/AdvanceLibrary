using AdvanceLibrary.Application.Contract.Repositries;
using AdvanceLibrary.Domain.Commends.CustomerBook;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.BookCustomer.Commends;
public class BorrowBookhandler : IRequestHandler<BorrowBookCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    public BorrowBookhandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<string> Handle(BorrowBookCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.BorrowedBook.BorrowBookAsync(request);
    }
}