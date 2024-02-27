using AdvanceLibrary.Domain.Dtos.Book;
using MediatR;

namespace AdvanceLibrary.Domain.Commends.Book;
public record UpdateBookCommand(
    Guid? id,
    string BookName,
    int? Quantity,
    string AuthorName
    ) : IRequest<UpdateBookDto>;
