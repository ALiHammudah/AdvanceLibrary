using AdvanceLibrary.Domain.Dtos.Book;
using MediatR;

namespace AdvanceLibrary.Domain.Commends.Book;
public record AddBookCommand(
    string Name,
    int Quantity,
    string Author
    ) : IRequest<AddBookDto>;