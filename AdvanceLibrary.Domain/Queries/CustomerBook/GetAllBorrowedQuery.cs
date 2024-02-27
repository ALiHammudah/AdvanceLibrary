using AdvanceLibrary.Domain.Dtos.Library;
using MediatR;

namespace AdvanceLibrary.Domain.Queries.CustomerBook;
public record GetAllBorrowedQuery : IRequest<List<BorrowedBookDto>>;
