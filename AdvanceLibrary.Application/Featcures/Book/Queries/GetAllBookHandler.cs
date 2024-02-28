using AdvanceLibrary.Application.Contract.Repositries;
using AdvanceLibrary.Domain.Dtos.Book;
using AdvanceLibrary.Domain.Queries.Book;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Book.Queries;
public class GetAllBookHandler : IRequestHandler<GetAllBookQuery, List<BookDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllBookHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BookDto>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Books.GetAllBookAsync();
    }
}
