using AdvanceLibrary.Domain.Dtos.Book;
using MediatR;

namespace AdvanceLibrary.Domain.Commends.Book;
public record UpdateBookCommand(
    Guid Id,
    string BookName,
    int? Quantity,
    string AuthorName
    ) : IRequest<UpdateBookDto>;
