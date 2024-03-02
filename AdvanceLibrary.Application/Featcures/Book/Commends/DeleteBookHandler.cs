using AdvanceLibrary.Application.Contract.Repositries;
using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Dtos.Api;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Book.Commends;
public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ApiDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteBookHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<ApiDto> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Books.DeleteBookAsync(request.id);
    }
}
