using AdvanceLibrary.Domain.Dtos.Api;
using MediatR;

namespace AdvanceLibrary.Domain.Commends.Book;
public record DeleteBookCommand(Guid id) : IRequest<ApiDto>;