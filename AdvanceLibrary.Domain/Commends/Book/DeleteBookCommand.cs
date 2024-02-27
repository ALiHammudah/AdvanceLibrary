using AdvanceLibrary.Domain.Dtos.Book;
using MediatR;

namespace AdvanceLibrary.Domain.Commends.Book;
public record DeleteBookCommand(Guid id) : IRequest<BookDto>;