using AdvanceLibrary.Domain.Dtos.Book;
using AdvanceLibrary.Domain.Queries.Book;
using MediatR;

namespace AdvanceLibrary.Application.Featcures.Book.Queries;
public class GetAllBookHandler : IRequestHandler<GetAllBookQuery, List<GetBookDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAllBookHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<GetBookDto>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
    {
        List<GetBookDto> allbook = await _unitOfWork.Books.GetAllBookAsync();
        return allbook;
    }
}
