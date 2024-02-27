using AdvanceLibrary.Domain.Commends.CustomerBook;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.BookCustomer.Commends;
public class ReceiveBookHandler : IRequestHandler<ReceiveBookCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    public ReceiveBookHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<string> Handle(ReceiveBookCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.BorrowedBook.ReciveBookAsync(request);
    }
}
