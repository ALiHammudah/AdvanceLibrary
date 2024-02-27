using AdvanceLibrary.Domain.Dtos.Book;
using MediatR;

namespace AdvanceLibrary.Domain.Queries.Book;
public record GetAllBookQuery : IRequest<List<GetBookDto>>;