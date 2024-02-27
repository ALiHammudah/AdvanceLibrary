using MediatR;

namespace AdvanceLibrary.Domain.Commends.CustomerBook;
public record ReceiveBookCommand(string BookName, string CustomerName) : IRequest<string>;