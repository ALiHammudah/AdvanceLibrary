using AdvanceLibrary.Domain.Dtos.Library;
using MediatR;

namespace AdvanceLibrary.Domain.Queries.CustomerBook;
public record GetBorrowedBookQuery(string BookName) : IRequest<BorrowedBookDto>;