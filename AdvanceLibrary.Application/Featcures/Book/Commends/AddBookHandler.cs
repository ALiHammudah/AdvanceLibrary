using AdvanceLibrary.Application.Contract.Repositries;
using AdvanceLibrary.Domain.Commends.Book;
using AdvanceLibrary.Domain.Dtos.Api;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Book.Commends;
public class AddBookHandler : IRequestHandler<AddBookCommand, ApiDto>
{
    private readonly IUnitOfWork _unitOfWork;
    public AddBookHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<ApiDto> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Books.AddBookAsync(request);
    }
}