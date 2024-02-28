using AdvanceLibrary.Domain.Dtos.Api;
using MediatR;

namespace AdvanceLibrary.Domain.Commends.Book;
public record AddBookCommand(
    string Name,
    int Quantity,
    string Author
    ) : IRequest<ApiDto>;