using MediatR;

namespace AdvanceLibrary.Domain.Commends.CustomerBook;
public record BorrowBookCommand(string BookName, string CustomerName) : IRequest<string>;
